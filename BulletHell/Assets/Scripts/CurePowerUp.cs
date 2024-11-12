using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurePowerUp : MonoBehaviour
{
    public int cure = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Health(cure);
            Destroy(gameObject);
        }
    }
}
