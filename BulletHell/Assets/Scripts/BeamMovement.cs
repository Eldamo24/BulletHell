using UnityEngine;

public class BeamMovement : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 8f);
    }

    private void Update()
    {
        transform.localPosition += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().OneShot();
            Destroy(gameObject);
        }
    }
}
