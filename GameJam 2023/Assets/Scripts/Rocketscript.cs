using UnityEngine;


public class Rocketscript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    Rigidbody2D body;
    public float damage = 10f;


    Vector2 currentVelocity;
    Vector2 lastVelocity;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

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

    }


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootBulletTowardsMouse();



        var loadingtime = (1f);
        //       loadingtime

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


    void ShootBulletTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate a spawn position a little bit away from the character
        float spawnDistance = 5.0f; // Distance away from the character
        Vector3 spawnPosition = transform.position + (Vector3)direction * spawnDistance;

        // Adjust z-axis to 0 to avoid placing the bullet behind or in front of the scene
        spawnPosition.z = 0;

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody2D component!");
        }

        // Destroy the bullet instance after 3 seconds
        Destroy(bullet, 3f);
        Debug.Log("Bullet instantiated and scheduled for destruction.");
    }
}



