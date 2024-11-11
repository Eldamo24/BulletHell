using UnityEngine;

public class BossPositionsController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")){
            BossController boss = other.GetComponent<BossController>();
            if(boss != null){
                boss.speed *= -1;
            }
        }
    }
}
