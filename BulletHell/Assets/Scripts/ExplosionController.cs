using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public int damage;

    [Header("Scale variables")]
    public float duration;
    public Vector2 actualScale;
    public Vector2 targetScale;

    public AudioSource audioSource;
    public AudioClip explosionSound;

    private void OnEnable()
    {
        audioSource =  GameObject.Find("SFX").GetComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSound);
        actualScale = transform.localScale;
        StartCoroutine("ScaleObject");
    }

    IEnumerator ScaleObject()
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector2.Lerp(actualScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Shield") && !collision.CompareTag("Saw"))
        {
            if(collision.GetComponent<BossController>() == null)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("ScaleObject");
    }
}
