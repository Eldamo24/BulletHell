using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MovimientoRigidBody : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 15;
    public float speedRotation = 20;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }


    // Se ejecuta de forma fija y se utiliza para todo lo que tenga que ver con calculos de fisica. Si usas el update comun da saltitos el movimiento.
    // El fixed Update tiene su propio delta Time.    
    public void FixedUpdate()    {

        Movement();

    }

    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //player.MovePosition(transform.position + vertical * transform.up * speed * Time.fixedDeltaTime);

        //Este es por si lo quisiera rotar con fisica.
        //player.MoveRotation(player.rotation - horizontal * rotation * Time.fixedDeltaTime);

        //Otra forma podria ser
        Vector2 movementV = transform.up * vertical * speed * Time.fixedDeltaTime;
        Vector2 movementH = transform.right * horizontal * speed * Time.fixedDeltaTime;
        player.MovePosition(player.position + movementV + movementH);

        float rotation = -horizontal * speedRotation * Time.fixedDeltaTime;
        player.MoveRotation(player.rotation + rotation);

    }


    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);

    }


    /* necesita que algun objetoeste en is trigger
        
       public void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        //print(collision.name);
        
        //Destruir objeto por tag
        
        if (collision.CompareTag("Triangle"))
        {
            Destroy(collision.gameObject);
        }

        

        //Destruir por layer

        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
        }
    }
    */

    //No necesita que hay un objeto en is trigger para funcionar
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
    */  
}