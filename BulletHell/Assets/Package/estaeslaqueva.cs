using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estaeslaqueva : MonoBehaviour
{
    public Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("....");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("te fuiste");
        }
    }

}
