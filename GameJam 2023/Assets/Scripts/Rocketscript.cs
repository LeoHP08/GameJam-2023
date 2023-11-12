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
        if (collision.gameObject.CompareTag("Enemy"))
        {

            GiveDamage(collision.gameObject);
        }
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

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
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



