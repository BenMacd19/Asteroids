using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [SerializeField] Asteroid[] asteroidPrefabs;

    [SerializeField] float spawnRate = 2f;
    [SerializeField] int spawnAmount = 1;
    [SerializeField] float spawnDistance = 15f;
    [SerializeField] float trajectoryVariance = 15f;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnRate);
    }

    void Spawn() {
        for (int i = 0; i < this.spawnAmount; i++) {

            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;

            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion spawnRotation = Quaternion.AngleAxis(variance, Vector3.forward);        

            Asteroid asteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], spawnPoint, spawnRotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            asteroid.SetTrajectory(spawnRotation * -spawnDirection);

        }
    }

}
