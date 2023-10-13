using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rollBoost = 2f;
    private float rollTime;
    public float RollTime;
    private bool rollOnce;

    private Vector2 moveInput;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isMoving;

    public SpriteRenderer charaterSR;

    //Khởi độnng khi game bắt đầu
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetComponentInChildren<Animator>();
        charaterSR = GetComponent<SpriteRenderer>();
    }

    //Cập nhật mỗi frame 
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");


       // kiem tra di chuyen

        isMoving = moveInput != Vector2.zero;
        
        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("Roll", true);
            speed += rollBoost;
            rollTime = RollTime;
            rollOnce = true;
        }

        if (rollTime <= 0 && rollOnce)
        {
            animator.SetBool("Roll", false);
            speed -= rollBoost;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }


    }

    //Cập nhật mỗi khoảng thời gian nhất định
    private void FixedUpdate()
    {
        moveInput.Normalize();
        rb.velocity = moveInput * speed;


        animator.SetBool("IsWalking", isMoving);
        



        // Rotate the character
        

        if (charaterSR != null)
        if (moveInput.x != 0)

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
