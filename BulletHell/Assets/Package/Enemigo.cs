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

    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.name == "Beholder(Clone)")
            anim = GetComponent<Animator>();
        else
            anim = null;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            if (gameObject.name == "Beholder(Clone)")
            {
                anim.SetBool("isDeath", true);
                Destroy(gameObject, 2f);
            }
            else
            {
                Destroy(gameObject);
            }
            
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
