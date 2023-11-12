using UnityEngine;
using TMPro;
public class Health_Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    // public TMP_Text healthText;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // healthText.text = "Health " + currentHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("hej" + currentHealth);
        
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