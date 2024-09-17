using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;

    // Start is called before the first frame update
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
            enemy.TakeDamage();
            Console.WriteLine(enemy.health);
            Destroy(gameObject);//Busca la funcion accediendo al componente (script) de la bala.
        }
    }
}
