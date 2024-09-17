using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMovementGrid : MonoBehaviour
{

    public float rotation = 0f;
    public float speed = 1f;
    private Vector2 spawnPoint;
    private float timer = 0f;


    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Movement(timer);

    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public Vector2 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

}
