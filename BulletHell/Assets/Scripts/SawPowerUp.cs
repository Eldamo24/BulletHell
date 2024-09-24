using UnityEngine;

public class SawPowerUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().ActiveSaws();  
            Destroy(gameObject);
        }
    }
}
