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

    [Header("Explosion")]
    public GameObject explosion;
    public float coolDownExplosion;
    public bool canUseExplosion;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        canUseExplosion = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            Instantiate(shoot, shootPosition.position, Quaternion.identity);
            Invoke("CoolDownShoot", coolDownTime);
        }
        if(Input.GetKeyDown(KeyCode.E) && canUseExplosion)
        {
            canUseExplosion = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Invoke("CoolDownExplosion", coolDownExplosion);
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

    void CoolDownShoot()
    {
        canShoot = true;
    }

    void CoolDownExplosion()
    {
        canUseExplosion = true;
    }
}
