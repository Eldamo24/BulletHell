using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement")]
    public Rigidbody2D rb;
    public float speed;

    [Header("Shoot")]
    public GameObject shoot;
    public bool canShoot;
    public Transform shootPosition;
    public float coolDownTime;

    [Header("Explosion")]
    public GameObject explosion;
    public float coolDownExplosion;
    public bool canUseExplosion;

    [Header("Shields")]
    public GameObject shieldA;
    public GameObject shieldB;

    [Header("Saws")]
    public GameObject saw1;
    public GameObject saw2;

    [Header("Animation")]
    public Animator anim;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioclipAttack;
    public AudioClip audioclipDeath;

    public int life = 9;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        canUseExplosion = true;
        shieldA.SetActive(true);
        shieldB.SetActive(false);
        anim = GetComponent<Animator>();
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (life <= 0)
        {
            audioSource.PlayOneShot(audioclipDeath);
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetTrigger("death");
            shieldA.SetActive(false);
            shieldB.SetActive(false);
            GameManager.instance.CheckLoose();
            this.enabled = false;
        }
        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            Shoot();
            anim.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.E) && canUseExplosion)
        {
            Explosion();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShieldsController();
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = transform.right * horizontal + transform.up * vertical;
        move = rb.position + move * speed * Time.deltaTime;
        move.x = Mathf.Clamp(move.x, -8f, 8f);
        move.y = Mathf.Clamp(move.y, -4f, 4f);
        rb.MovePosition(move);
    }

    void Shoot()
    {
        canShoot = false;
        Instantiate(shoot, shootPosition.position, Quaternion.identity);
        audioSource.PlayOneShot(audioclipAttack);
        Invoke("CoolDownShoot", coolDownTime);
    }

    void Explosion()
    {
        canUseExplosion = false;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Invoke("CoolDownExplosion", coolDownExplosion);
    }

    void ShieldsController()
    {
        if (shieldA.activeSelf)
        {
            shieldA.SetActive(false);
            shieldB.SetActive(true);
        }
        else
        {
            shieldA.SetActive(true);
            shieldB.SetActive(false);
        }
    }

    void CoolDownShoot()
    {
        canShoot = true;
    }

    void CoolDownExplosion()
    {
        canUseExplosion = true;
    }

    public void ActiveSaws()
    {
        saw1.SetActive(true);
        saw2.SetActive(true);
    }

    public void TakeDamage()
    {
        life -= 1;
        UIController.instance.UpdateLifeBar(life);
        anim.SetTrigger("hit");
        //UIController.instance.UpdateLifeText(life);
    }

    public void OneShot()
    {
        life -= 9;
        UIController.instance.UpdateLifeBar(life);
    }

    public void Health(int cure)
    {
        life += cure;
        if (life >= 9)
        {
            life = 9;
        }
        //UIController.instance.UpdateLifeText(life);
        UIController.instance.UpdateLifeBar(life);
    }
}
