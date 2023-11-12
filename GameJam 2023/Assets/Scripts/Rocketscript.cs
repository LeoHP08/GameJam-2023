using UnityEngine;


public class Rocketscript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 2f;
    Rigidbody2D body;


    Vector2 currentVelocity;
    Vector2 lastVelocity;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootBulletTowardsMouse();



        var loadingtime = (1f);
        //       loadingtime

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



