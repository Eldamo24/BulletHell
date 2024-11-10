using UnityEngine;

public class BulletMovementLineal : MonoBehaviour
{
    public float speed = 3f;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector3 dir, float bulletSpeed)
    {
        direction = dir;
        speed = bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
