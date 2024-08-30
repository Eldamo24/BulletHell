using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject shoot;
    public int waves;

    private void Start()
    {
        StartCoroutine("SpiralShoot");    
    }

    IEnumerator SpiralShoot()
    {
        for(int i = 0; i < waves; i++)
        {
            float angle = 0;
            while (angle <= 360)
            {
                int rand = Random.Range(0, 2);
                GameObject shootInstantiated = Instantiate(shoot, transform.position, Quaternion.Euler(0f, 0f, angle));
                if(rand == 0)
                {
                    shootInstantiated.GetComponent<SpriteRenderer>().color = Color.green;
                    shootInstantiated.tag = "EnemyShootA";
                }
                else
                {
                    shootInstantiated.GetComponent<SpriteRenderer>().color = Color.red;
                    shootInstantiated.tag = "EnemyShootB";
                }
                angle += 20;
                yield return new WaitForSeconds(.05f);
            }
        }
    }
}
