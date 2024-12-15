using UnityEngine;

public class LastEnemyBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public bool reached = false;
    private bool calculatedPosition = false;
    public float speed = 1f;
    public Vector3 newPosition = Vector3.zero;

    [Header("Shoot")]
    public GameObject[] projectilePrefab;
    public int totalProjectiles = 36;
    public float spiralRadius = 2f;
    public float projectileSpeed = 5f;
    private bool invoked = false;

    public int health = 100;

    public EnemySpawner spawner;
    public IsOcuppied spawnPos;
    public bool isDead = false;

    [Header("Animations")]
    private Animator anim;

    [Header("Sounds")]
    public AudioClip clipHit;
    public AudioClip clipDeath;
    public AudioSource audioSource;

    private void Awake()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        anim = GetComponent<Animator>();
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!reached && !isDead)
        {
            if (!calculatedPosition)
            {
                calculatedPosition = true;
                CalculateNewPosition();
            }
            else
            {
                anim.SetBool("movement", true);
                transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                if (transform.position == newPosition)
                {
                    reached = true;
                    anim.SetBool("movement", false);
                }
            }
        }
        else
        {
            if (!isDead)
            {
                if (!invoked)
                {
                    Invoke("GenerateSpiral", 2f);
                    invoked = true;
                }
            }
        }
    }

    private void CalculateNewPosition()
    {
        newPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(0f, 4f), 0f);
    }

    private void GenerateSpiral()
    {
        float angleStep = 360f / totalProjectiles;
        int index = Random.Range(0, projectilePrefab.Length);
        anim.SetTrigger("attack");
        for (int i = 0; i < totalProjectiles; i++)
        {

            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);


            Vector3 spawnPosition = transform.position + new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * spiralRadius,
                Mathf.Sin(angle * Mathf.Deg2Rad) * spiralRadius,
                0f
            );


            GameObject projectile = Instantiate(projectilePrefab[index], spawnPosition, rotation);
        }
        reached = false;
        calculatedPosition = false;
        invoked = false;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("damage");
        audioSource.PlayOneShot(clipHit);
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

    private void OnDestroy()
    {
        spawner.EnemyDestroyed();
        spawnPos.IsTheSpawnerOcuppied();
        spawnPos = null;
        GameManager.instance.AddEnemyDefeated();
    }
}
