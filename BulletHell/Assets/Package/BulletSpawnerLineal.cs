using UnityEngine;

public class BulletSpawnerLineal : MonoBehaviour
{

    public GameObject bullet;
    public Transform player;
    public float timer = 0f;
    public float cooldown = 0.5f;
    public float speed = 1.5f;
    public float rangeOfVision = 8.5f;

    public void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }
    public void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < rangeOfVision)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0f;
                Shoot();
            }

        }
    }

    public void Shoot()
    {
        GameObject bulletPrefab = Instantiate(bullet, transform.position, transform.rotation);
        Vector3 direction = (player.position - transform.position).normalized;
        bulletPrefab.GetComponent<BulletMovementLineal>().SetDirection(direction, speed);
    }
}
