using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    internal int currenthealth;

    void Start()
    {
        currentHealth = maxHealth;
    }



    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        // Handle the character's death here (e.g., destroy the game object, play an animation, etc.)
        Destroy(gameObject);
    }
}