using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementLineal : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += direction * speed * Time.deltaTime;

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    public void SetDirection(Vector3 dir, float bulletSpeed)
    {
        direction = dir;
        speed = bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
