using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerUpPrefabs;

    [SerializeField] float spawnRate = 2f;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] int maxPowerUps = 3;
    [SerializeField] float spawnDistance = 15f;
    [SerializeField] float trajectoryVariance = 15f;
    [SerializeField] float speed;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }

    void Spawn() {

        if (GameObject.FindGameObjectsWithTag("Power Up").Length >= maxPowerUps) {
            return;
        } else {
            for (int i = 0; i < this.spawnAmount; i++) {

                Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
                Vector3 spawnPoint = transform.position + spawnDirection;

                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);        

                GameObject powerUp = Instantiate(powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)], spawnPoint, spawnRotation);
                Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D>();
                rb.AddForce(speed * (spawnRotation * -spawnDirection));

                Destroy(powerUp, 15f);

            }
        }

        
    }

}
