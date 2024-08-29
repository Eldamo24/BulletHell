using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    public Rigidbody2D rb;
    public float speed;

    [Header("Shoot")]
    public GameObject shoot;
    public bool canShoot;
    public Transform shootPosition;
    public float coolDownTime;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            Instantiate(shoot, shootPosition.position, Quaternion.identity);
            Invoke("CoolDown", coolDownTime);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = transform.right * horizontal + transform.up * vertical;
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }

    void CoolDown()
    {
        canShoot = true;
    }
}
