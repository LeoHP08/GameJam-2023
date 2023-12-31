using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLucaz : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    SpriteRenderer spriteRenderer;

    [SerializeField] public float runSpeed = 20.0f;

    Vector2 currentVelocity; // Used for SmoothDamp
    public float smoothTime = 0.3f; // Time to reach the target speed
    private Animator animator;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal > 0)
            spriteRenderer.flipX = false;
        if (horizontal < 0)
            spriteRenderer.flipX = true;


    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {

            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }


        Vector2 targetVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        body.velocity = Vector2.SmoothDamp(body.velocity, targetVelocity, ref currentVelocity, smoothTime);
    }
}
