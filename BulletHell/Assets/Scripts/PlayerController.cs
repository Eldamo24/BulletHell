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

    [Header("Saws")]
    public GameObject saw1;
    public GameObject saw2;

    public int life = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        canUseExplosion = true;
        shieldA.SetActive(true);
    }

    void Update()
    {
        if(life <= 0)
        {
            GameManager.instance.CheckLoose();
        }
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.E) && canUseExplosion)
        {
            Explosion();
        }
        if(Input.GetKeyDown(KeyCode.Q))
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
        move = rb.position + move * speed * Time.deltaTime;
        move.x = Mathf.Clamp(move.x, -8f, 8f);
        move.y = Mathf.Clamp(move.y, -4f, 4f);
        rb.MovePosition(move);
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

    public void TakeDamage()
    {
        life -= 10;
        UIController.instance.UpdateLifeText(life);
    }
}
