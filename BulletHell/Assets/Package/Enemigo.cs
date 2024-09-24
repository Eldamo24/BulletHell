using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int health = 100;
    public EnemySpawner spawner;
    public IsOcuppied spawnPos;

    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        spawner.EnemyDestroyed();
        spawnPos.IsTheSpawnerOcuppied();
        spawnPos = null;
        GameManager.instance.AddEnemyDefeated();
    }
}
