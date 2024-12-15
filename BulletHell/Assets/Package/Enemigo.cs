using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public int health = 100;
    public EnemySpawner spawner;
    public IsOcuppied spawnPos;
    public float maxDistance = 100f;
    public float movementSpeed = 3f;
    public Transform player;
    public Rigidbody2D rb;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip clipHit;
    public AudioClip clipDeath;
    public bool isDead = false;

    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Follow();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSource.PlayOneShot(clipHit);
        if(gameObject.name != "Beholder(Clone)")
            anim.SetTrigger("damage");
        if (health <= 0)
        {
            isDead = true;
            audioSource.PlayOneShot(clipDeath);
            GetComponent<BoxCollider2D>().enabled = false;
            health = 0;
            anim.SetBool("isDeath", true);
            Destroy(gameObject, 2f);
        }
    }

    public void Follow()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > maxDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
        }
    }

    public void OnDestroy()
    {
        spawner.EnemyDestroyed();
        spawnPos.IsTheSpawnerOcuppied();
        spawnPos = null;
        GameManager.instance.AddEnemyDefeated();
    }
}
