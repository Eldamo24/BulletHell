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

    [Header("Shields")]
    public GameObject shieldA;
    public GameObject shieldB;
    public bool activeShields;

    [Header("Saws")]
    public GameObject saw1;
    public GameObject saw2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        canUseExplosion = true;
        activeShields = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.E) && canUseExplosion)
        {
            Explosion();
        }
        if(activeShields && Input.GetKeyDown(KeyCode.Q))
        {
            ShieldsController();
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

    void Shoot()
    {
        canShoot = false;
        Instantiate(shoot, shootPosition.position, Quaternion.identity);
        Invoke("CoolDownShoot", coolDownTime);
    }

    void Explosion()
    {
        canUseExplosion = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Invoke("CoolDownExplosion", coolDownExplosion);
    }

    void ShieldsController()
    {
        if (shieldA.activeSelf)
        {
            shieldA.SetActive(false);
            shieldB.SetActive(true);
        }
        else
        {
            shieldA.SetActive(true);
            shieldB.SetActive(false);
        }
    }

    void CoolDownShoot()
    {
        canShoot = true;
    }

    void CoolDownExplosion()
    {
        canUseExplosion = true;
    }

    public void ActiveSaws()
    {
        saw1.SetActive(true);
        saw2.SetActive(true);
    }
}
