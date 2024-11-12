using UnityEngine;

public class SawPowerUp : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        audioSource = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
            collision.gameObject.GetComponent<PlayerController>().ActiveSaws();  
            Destroy(gameObject);
        }
    }
}
