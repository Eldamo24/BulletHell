using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().activeShields = true;
            collision.gameObject.GetComponent<PlayerController>().shieldA.SetActive(true);
            Destroy(gameObject);
        }
    }
}
