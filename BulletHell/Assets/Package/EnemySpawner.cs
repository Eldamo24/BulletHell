using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 3;
    private int enemyCount = 0;
    private int amountOfEnemies = 20;
    private int enemyTotalCounter = 0;
    public Transform[] spawnBoss;
    public GameObject[] bossPrefab;
    public bool bossSpawned;

    private void Start()
    {
        bossSpawned = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (enemyCount < maxEnemies && enemyTotalCounter < amountOfEnemies)
        {
            SpawnEnemy();
        }
        if (GameManager.instance.enemiesDefeated >= 20 && !bossSpawned)
        {
            SpawnBoss();
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

    public void SpawnBoss()
    {
        Transform spawnBos = spawnBoss[Random.Range(0, spawnBoss.Length)];
        int index = Random.Range(0, bossPrefab.Length);
        GameObject boss = Instantiate(bossPrefab[index], spawnBos.position, Quaternion.identity);
        boss.GetComponent<Enemigo>().spawnPos = spawnBos.GetComponent<IsOcuppied>();
        boss.GetComponent<Enemigo>().spawnPos.IsTheSpawnerOcuppied();
        bossSpawned = true;
    }
}
