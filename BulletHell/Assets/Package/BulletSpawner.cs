using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 1f;
    private float cooldown = 0f;
    public float fireRate = 0.1f;
    public float rotationSpeed = 5f;
    public int bulletAmount = 10;
    public float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        cooldown -= Time.deltaTime;

        if (cooldown <= 0f && !GetComponentInParent<Enemigo>().isDead)
        {
            ShootCircle();
            cooldown = fireRate;
        }
    }

    public void ShootCircle()
    {
            for (int i = 0; i < bulletAmount; i++)
            {
                float angle = 0f;
                angle = currentAngle + (i * (360f / bulletAmount));
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                GameObject bulletPrefab = Instantiate(bullet, transform.position, rotation);
                Destroy(bulletPrefab, 10f);
                EnemyBullet bulletMovement = bulletPrefab.GetComponent<EnemyBullet>();
                bulletMovement.SetSpeed(bulletSpeed);
            }
    }


}
