using UnityEngine;

public class ShieldsCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if((gameObject.name == "ShieldA" && collision.CompareTag("EnemyShootA")) || (gameObject.name == "ShieldB" && collision.CompareTag("EnemyShootB")))
       {
            Destroy(collision.gameObject);
       }
    }
}
