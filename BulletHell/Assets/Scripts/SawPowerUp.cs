using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPowerUp : MonoBehaviour
{
    public GameObject saw1;
    public GameObject saw2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            saw1.SetActive(true);   
            saw2.SetActive(true);   
            Destroy(gameObject);
        }
    }
}
