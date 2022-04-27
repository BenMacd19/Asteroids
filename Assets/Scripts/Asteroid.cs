using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer asteroidRenderer;

    [SerializeField] Asteroid[] largeAsteroidPrefabs;
    [SerializeField] Asteroid[] mediumAsteroidPrefabs;
    [SerializeField] Asteroid[] smallAsteroidPrefabs;

    public int pointValue = 100;
    public float size = 1f;
    public float minSize = 0.9f;
    public float maxSize = 1.1f;
    public float speed = 17.5f;
    public float fadeSpeed = 10f;
    public float shakeMagnitude = 5f;
    public float shakeLength = 0.1f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        asteroidRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

        // Set a random rotation for the asteroid
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
        // Set the size of the asteroid
        transform.localScale = Vector3.one * size;

        rb.mass = size;

    }

    public void SetTrajectory(Vector2 direction) {
        rb.AddForce(speed * direction);
        InvokeRepeating("FadeOut", 29f, 0.04f);
        Destroy(gameObject, 30f);
    }

    void FadeOut() {
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");

        Color asteroidColor = GetComponent<SpriteRenderer>().color;
        float fadeAmount = asteroidColor.a - (fadeSpeed * Time.deltaTime);

        asteroidColor = new Color(asteroidColor.r, asteroidColor.g, asteroidColor.b, fadeAmount);
        GetComponent<SpriteRenderer>().color = asteroidColor;
        
        if (asteroidColor.a <= 0) {
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Projectile") {
            
            CinemachineShake.Instance.ShakeCamera(shakeMagnitude, shakeLength);
            FindObjectOfType<GameManager>().AddScore(this);

            SplitAsteroid();
            SplitAsteroid();
            
            Destroy(gameObject);

        }
    }

    void SplitAsteroid() {

        Vector2 position = transform.position;
        position += Random.insideUnitCircle * 5f;

        if (gameObject.tag == "Asteroid Large") {
            Asteroid half = Instantiate(mediumAsteroidPrefabs[Random.Range(0, mediumAsteroidPrefabs.Length)], position, transform.rotation);
            half.SetTrajectory(Random.insideUnitCircle.normalized * speed * 2);
        }

        if (gameObject.tag == "Asteroid Medium") {
            Asteroid half = Instantiate(smallAsteroidPrefabs[Random.Range(0, smallAsteroidPrefabs.Length)], position, transform.rotation);
            half.SetTrajectory(Random.insideUnitCircle.normalized * speed);
        }

        if (gameObject.tag == "Asteroid Small") {
            
        }

    }

}
