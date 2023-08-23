using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [Tooltip("The time between spawning each health pickup")]
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject healthPrefab;

    float timer;
    float randomY;
    float randomX;
    void Start()
    {
        timer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            randomX = Random.Range(-1, 1);
            randomY = Random.Range(-1, 1);
            Vector3 spawnPoint = new Vector3(randomX, randomY, 0);
            Instantiate(healthPrefab, spawnPoint, Quaternion.identity);
            timer = spawnTimer;
        }
    }
}
