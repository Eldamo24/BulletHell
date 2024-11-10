using UnityEngine;

public class SadakoScript : MonoBehaviour
{
    public float rangeOfVision;
    public Transform player;
    public Vector3 initialPosition;
    public float movementSpeed = 5f;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        player = FindObjectOfType<PlayerController>().transform;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeOfVision);
    }

}
