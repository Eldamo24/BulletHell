using System;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed;
    public GameObject beam;
    public float waitTime;
    public float beamCooldown;
    public Transform[] lasersPosition;
    public AudioSource audioSource;
    public AudioClip shootSound;

    private void Start()
    {
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if(Time.time > waitTime)
        {
            Attack();
            waitTime = Time.time + beamCooldown;
        }
    }

    private void Attack()
    {
        audioSource.PlayOneShot(shootSound);
        Instantiate(beam, lasersPosition[0].position, Quaternion.identity);
        Instantiate(beam, lasersPosition[1].position, Quaternion.identity);
    }
}
