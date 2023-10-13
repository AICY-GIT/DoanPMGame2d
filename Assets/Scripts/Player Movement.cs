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
    public SpriteRenderer charaterSR;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetComponentInChildren<Animator>();
        charaterSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

       // kiem tra di chuyen
        isMoving = moveInput != Vector2.zero;
    }

    private void FixedUpdate()
    {
        moveInput.Normalize();
        rb.velocity = moveInput * speed;

        animator.SetBool("IsWalking", isMoving);

        // Rotate the character
        if (charaterSR != null)
        {
            if (moveInput.x != 0)
            {
                if (moveInput.x > 0)
                {
                    charaterSR.transform.localScale = new Vector2(1, 1);
                }
                else
                {
                    charaterSR.transform.localScale = new Vector2(-1, 1);
                }
            }
        }
    }

}
