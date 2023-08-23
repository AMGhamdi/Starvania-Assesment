using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("The time between spawning each enemy")]
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject enemyPrefab;
    [Tooltip("The max number of enemies that can be in the map at one time")]
    [SerializeField] float MaxNumOfEnemies = 3;
    
    float timer;
    float randomY;
    float randomX;

    public ArrayList listOfEnemies;
    private void Awake()
    {
        listOfEnemies = new ArrayList();
    }
    void Start()
    {
        timer = spawnTimer;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && listOfEnemies.Count<MaxNumOfEnemies)
        {
            randomX = Random.Range(-1, 1);
            randomX = Random.Range(-1, 1);
            Vector3 spawnLocation = new Vector3(randomX, randomY, 0);
            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
            timer = spawnTimer;
        }
    }
}
