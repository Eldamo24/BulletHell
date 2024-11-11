using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 3;
    private int enemyCount = 0;
    private int amountOfEnemies = 20;
    private int enemyTotalCounter = 0;


    // Update is called once per frame
    void Update()
    {
        if (enemyCount < maxEnemies && enemyTotalCounter < amountOfEnemies)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (!spawnPoint.gameObject.GetComponent<IsOcuppied>().isOcuppied)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            GameObject enemy = Instantiate(enemyPrefab[index], spawnPoint.position, spawnPoint.rotation);
            enemy.GetComponent<Enemigo>().spawnPos = spawnPoint.GetComponent<IsOcuppied>();
            enemy.GetComponent<Enemigo>().spawnPos.IsTheSpawnerOcuppied();
            enemyCount++;
            enemyTotalCounter++;
        }
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
    }
}
