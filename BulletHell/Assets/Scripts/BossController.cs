using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
        
    
}
