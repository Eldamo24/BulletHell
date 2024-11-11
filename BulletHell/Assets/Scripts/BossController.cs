using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;
    public int shootsAmount;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject beams;
    public Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        //LinealShoot();
    }

    void LinealShoot(){
        for(int i = 0; i < shootsAmount; i++){
            float distance = Vector2.Distance(transform.position, player.position);
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Instantiate(bullet2, transform.position, Quaternion.Euler(0,0, angle));
        }

        
    }
}
