using UnityEngine;

public class SawController : MonoBehaviour
{
    public Transform player;
    public float speed;

    void Update()
    {
        transform.RotateAround(player.position, transform.forward, speed * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("EnemyShoot"))
        {
            if(collision.GetComponent<BossController>() == null)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
