using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1f;
    public float fireRate;
 
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {

        /* if (timer > ttl) Destroy(gameObject);
         timer += Time.deltaTime;
         transform.position = Movement(timer);


     }

     private Vector2 Movement(float timer)
     {
         float horizontal = timer * speed * transform.right.x;
         float vertical = timer * speed * transform.right.y;
         return new Vector2(horizontal+spawn.x, vertical+spawn.y);


     }
        */

    transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

     public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
