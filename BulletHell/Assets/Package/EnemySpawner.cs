using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 3;
    private int enemyCount = 0;
    private int enemiesDead = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < maxEnemies)
        {
            SpawnEnemy();
            enemyCount++;
        }
    }

    public void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
    }
}
