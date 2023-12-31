using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public float attackDamage = 20f;
    public float moveSpeed = 2f;
    public Transform player;
    private Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    public GameObject particleprefab;
    public float offsetRange = 1.0f;
    public float spawnScale = 0.5f;




    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Ensure your player object is tagged as "Player"
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        MoveTowardsPlayer();


    }

    void FixedUpdate()
    {



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer(collision.gameObject);
            Debug.Log("skade!!!" + currentHealth);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        print(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void AttackPlayer(GameObject player)
    {
        Health_Player playerHealth = player.GetComponent<Health_Player>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            if (direction.x > 0)
                spriteRenderer.flipX = false;
            if (direction.x < 0)
                spriteRenderer.flipX = true;

            if (direction.x != 0 || direction.y != 0)
            {
                animator.SetFloat("Speed", 0.5f);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
    }

    void Die()
    {
        GameObject.Find("killmanger").GetComponent<killmanger>().kill += 1;
        GameObject particle1 = InstantiateAndScaleParticle(particleprefab);
        GameObject particle2 = InstantiateAndScaleParticle(particleprefab);   
        
        // Handle the enemy's death here (e.g., play an animation, destroy the game object, etc.)
        Destroy(gameObject);
    }
    private Vector3 GetOffsetPosition()
    {
        Vector3 randomOffset = Random.insideUnitSphere * offsetRange;
        return transform.position + randomOffset;
    }
    private GameObject InstantiateAndScaleParticle(GameObject prefab)
    {
        GameObject particle = Instantiate(prefab, GetOffsetPosition(), Quaternion.identity);
        particle.transform.localScale = Vector3.one * spawnScale;
        return particle;
    }
}


    
