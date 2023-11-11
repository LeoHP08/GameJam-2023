using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public float attackDamage = 20f;
    public float moveSpeed = 2f;
    public Transform player;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform; // Ensure your player object is tagged as "Player"
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AttackPlayer(collision.gameObject);
    
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
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    void Die()
    {
        // Handle the enemy's death here (e.g., play an animation, destroy the game object, etc.)
        Destroy(gameObject);
    }
}