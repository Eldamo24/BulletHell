using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public int damage;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }


    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent<Enemigo>(out Enemigo enemy))
            {
                enemy.TakeDamage(damage);
            }
            if (collision.TryGetComponent<LastEnemyBehaviour>(out LastEnemyBehaviour enemigo))
            {
                enemigo.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
