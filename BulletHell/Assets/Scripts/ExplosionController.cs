using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public int damage;

    [Header("Scale variables")]
    public float duration;
    public Vector2 actualScale;
    public Vector2 targetScale;

    private void OnEnable()
    {
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
        if (!collision.CompareTag("Player") && !collision.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("ScaleObject");
    }
}
