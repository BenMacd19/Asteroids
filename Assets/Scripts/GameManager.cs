using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    PlayerManager player;
    public int lives = 3;
    public int score = 0;

    public float targetTime = 60.0f;
    [SerializeField] TextMeshProUGUI timer;
 
    public GameOver gameOverScreen;

    void Awake() {
        Instance = this;
    }

    private void Start() {
        player = FindObjectOfType<PlayerManager>();
    }

    private void Update() {
        targetTime -= Time.deltaTime;
        timer.text = targetTime.ToString("F2");
        if (targetTime <= 0.0f) {
            GameOver();
        }
    }

    public void PlayerDied() {
        lives--;
        if (lives <= 0) {
            GameOver();
            return;
        }
        Invoke("Respawn", 3f);
    }

    void Respawn() {
        player.transform.position = Vector3.zero;
        player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        player.gameObject.SetActive(true);
        player.GetComponent<SpriteRenderer>().color =  new Color(1f,1f,1f,0.5f);
        Invoke("TurnOnCollisions", 3f);
    }

    void TurnOnCollisions() {
        player.gameObject.layer = LayerMask.NameToLayer("Player");
        player.GetComponent<SpriteRenderer>().color =  new Color(1f,1f,1f,1);
    }

    public void AddScore(Asteroid asteroid) {
        score += asteroid.pointValue;
    }

    void GameOver() {
        gameOverScreen.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        timer.enabled = false;
    }

}
