using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SadakoScript : MonoBehaviour
{
    public float rangeOfVision;
    public int life;
    public Transform player;
    public Vector3 initialPosition;
    public float rotationSpeed = 2f;

    // Start is called before the first frame update
    public void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        Follow();
    }

    public void Follow()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < rangeOfVision)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            //Quaternion target = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            transform.rotation = Quaternion.Euler(0, 0, angle);

        }

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeOfVision);
    }

}
