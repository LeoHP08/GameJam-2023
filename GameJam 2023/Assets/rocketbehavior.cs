using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rocketbehavior : MonoBehaviour
{
    public float damage = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Assuming the enemy has a script that can take damage
            var enemyHealth = collision.gameObject.GetComponent<Enemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        // Destroy the bullet regardless of what it hit
        Destroy(gameObject);
    }
}
