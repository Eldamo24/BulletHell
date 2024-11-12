using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    int damage = 20;

    void Start()
    {
        Destroy(gameObject, 3f); //Destruye la bala despues de 3 segundos. O el numero que le pongamos.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemigo enemy = collision.GetComponent<Enemigo>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);//Busca la funcion accediendo al componente (script) de la bala.
        }
    }
}
