using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int health = 10;
    public EnemySpawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        //spawner.EnemyDestroyed();
        GameManager.instance.AddEnemyDefeated();
    }
}
