using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float speed;
    public float resetPosition;

    private void Update()
    {
        transform.position += -Vector3.up * speed * Time.deltaTime;
        if(transform.position.y <= resetPosition)
        {
            transform.position = Vector3.zero;
        }
    }
}
