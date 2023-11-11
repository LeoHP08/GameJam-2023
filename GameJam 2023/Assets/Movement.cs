using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;
    public float reflectionDampening = 0.5f; 
    public float smoothTime = 0.3f; 

    Vector2 currentVelocity; 
    Vector2 lastVelocity; 

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) 
        {
            
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        Vector2 targetVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        body.velocity = Vector2.SmoothDamp(body.velocity, targetVelocity, ref currentVelocity, smoothTime);
        lastVelocity = body.velocity; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ReflectMovement(collision);
    }

    void ReflectMovement(Collision2D collision)
    {
        Vector2 inNormal = collision.contacts[0].normal;
        Vector2 newVelocity = Vector2.Reflect(lastVelocity, inNormal) * reflectionDampening;
        body.velocity = newVelocity;
    }
}