using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpManager : MonoBehaviour
{
    public List<GameObject> powerUps;
    public List<Transform> spawnPoints;
    private float luckyPercentage = 50;
    private float coolDown = 30;
    private float waitTime = 0;

    private void Start()
    {
        waitTime = Time.time + coolDown;
    }

    private void Update()
    {
        if (Time.time > waitTime)
        {
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        int percentage = UnityEngine.Random.Range(1, 101);
        if(percentage >= luckyPercentage)
        {
            int index = UnityEngine.Random.Range(0, powerUps.Count);
            int indexSpawn = UnityEngine.Random.Range(0, spawnPoints.Count);
            Instantiate(powerUps[index], spawnPoints[indexSpawn].position, Quaternion.identity);
        }
        waitTime = Time.time + coolDown;
    }
}
