using UnityEngine;

public class CurePowerUp : MonoBehaviour
{
    public int cure = 3;
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
            collision.gameObject.GetComponent<PlayerController>().Health(cure);
            Destroy(gameObject);
        }
    }
}
