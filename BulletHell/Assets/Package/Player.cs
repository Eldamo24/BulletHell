using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //Creo el movimiento.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
        
        //El normalized sirve para limitar el valor del modulo a 1 por ende normaliza la velocidad.
        
        transform.position += direction * speed * Time.deltaTime;

        //Si queremos rotar tenemos que usar el eje Z, asi que usamos el transform.forward.

        transform.Rotate(transform.forward * horizontal * Time.deltaTime);

    }
}
