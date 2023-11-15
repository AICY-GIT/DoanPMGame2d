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
    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;
    public GameObject ghostEffect;
    public float ghostDelaySeconds;
    private Coroutine dashEffectCoroutine; 

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
        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false) 
        {
            speed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            StartDashEffect();
        }

        if (_dashTime <= 0 && isDashing == true)
        {

            speed -= dashBoost;
            isDashing=false;
            StartDashEffect();
        }
        else 
        {
            
            _dashTime -= Time.deltaTime;
        }
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

    private void StopDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }
    private void StartDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }
    IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            ghost.GetComponent<SpriteRenderer>().sprite = currentSprite;


            Destroy(ghost, 0.5f);

            yield return new WaitForSeconds(ghostDelaySeconds);
        }    

    }


}
