using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpManager : MonoBehaviour
{
    public List<GameObject> powerUps;
    public List<Transform> spawnPoints;
    public float luckyPercentage = 50;
    private float coolDown = 30;
    private float waitTime = 0;
    public GameObject powerUp;
    public float timeToDestroy = 20f;

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
        int percentage = Random.Range(1, 101);
        if(percentage >= luckyPercentage)
        {
            int index = Random.Range(0, powerUps.Count);
            int indexSpawn = Random.Range(0, spawnPoints.Count);
            powerUp = Instantiate(powerUps[index], spawnPoints[indexSpawn].position, Quaternion.identity);
            powerUp.transform.parent = GameObject.Find("Grid").transform;
            Invoke("DestroyPowerUp", timeToDestroy);
            
        }
        waitTime = Time.time + coolDown;
    }

    private void DestroyPowerUp()
    {
        Destroy(powerUp);
    }


}
