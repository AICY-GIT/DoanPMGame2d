using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveInput;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isMoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        // Check if the player is moving
        isMoving = moveInput != Vector2.zero;
    }

    private void FixedUpdate()
    {
        moveInput.Normalize();
        rb.velocity = moveInput * speed;

        // Set the walking animation based on movement
        animator.SetBool("IsWalking", isMoving);

        // Flip the character based on movement direction
        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }
}
