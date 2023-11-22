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
    private bool isDashing = false;
    public GameObject ghostEffect;
    public float ghostDelayseconds;
    public Coroutine DashEffectCorotine;
    private float dashDelay = 1f;
    private float timeSinceLastDash;
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
        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && isDashing == false&& Time.time - timeSinceLastDash >= dashDelay)
        {
            speed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            StartDashEffect();
            timeSinceLastDash = Time.time;
        }

        if (_dashTime <= 0 && isDashing == true)
        {

            speed -= dashBoost;
            isDashing = false;
            StopDashEffect();
        }
        else
        {

            _dashTime -= Time.deltaTime;
        }

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
    void StopDashEffect()
    {
        if (DashEffectCorotine != null)
        {
            StopCoroutine(DashEffectCorotine);
        }
    }
    void StartDashEffect()
    {
        if(DashEffectCorotine != null)
        {
            StopCoroutine(DashEffectCorotine);
            DashEffectCorotine = StartCoroutine(dashEffectCoroutine());
        }
    }
    IEnumerator dashEffectCoroutine()
    {
        while (true)
        {
            GameObject ghost = Instantiate(ghostEffect, transform.position, transform.rotation);
            Sprite currentSprite = charaterSR.sprite;
            ghost.GetComponentInChildren<SpriteRenderer>().sprite = currentSprite;
            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghostDelayseconds);
        }
    }
}
