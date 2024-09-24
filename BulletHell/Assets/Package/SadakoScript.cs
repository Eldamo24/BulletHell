using UnityEngine;

public class SadakoScript : MonoBehaviour
{
    public float rangeOfVision;
    public Transform player;
    public Vector3 initialPosition;
    public float rotationSpeed = 2f;


    void Start()
    {
        initialPosition = transform.position;
        player = FindObjectOfType<PlayerController>().transform;
    }

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
