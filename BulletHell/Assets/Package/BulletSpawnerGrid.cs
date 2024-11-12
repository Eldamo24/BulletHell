using System;
using UnityEngine;

public class BulletSpawnerGrid : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet2;
    public float speed = 1.5f;
    public float fireRate = 0.01f;
    public int seconds = 0;
    private GameObject spawnedBullet;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= fireRate)
        {
            seconds = Convert.ToInt32(Time.time % 60);
            if (seconds % 2 == 0)
            {
                FireYellow();
                timer = 0;
            }
            else
            {
                FireGreen();
                timer = 0;
            }
        }
    }

    private void FireYellow()
    {
        if (bullet != null)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletMovementGrid>().speed = speed;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }

    private void FireGreen()
    {
        if (bullet2 != null)
        {
            spawnedBullet = Instantiate(bullet2, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<BulletMovementGrid>().speed = speed;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
          