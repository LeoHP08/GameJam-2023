using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float damage = 10f; // Damage the character can give to others

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            GiveDamage(collision.gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void GiveDamage(GameObject enemy)
    {
        print("GiveDamage");
        // Assuming the enemy also has a Health script
        var enemyHealth = enemy.GetComponent<Enemy>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    void Die()
    {
        // Handle the character's death here (e.g., destroy the game object, play an animation, etc.)
        Destroy(gameObject);
    }
}