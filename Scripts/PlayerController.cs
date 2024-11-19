using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spRenderer;
    // Mascara de layer que será usada para verificar a colisão
    // entre os objetos
    [SerializeField] private LayerMask whatIsGround;

    [Header("Player Variables")]
    [SerializeField] float xInput;
    [SerializeField] float ySpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float activeSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private float groundCheckRadius;

    [Header("Animation Controllers")]
    [SerializeField] private bool idle;
    [SerializeField] private int jumpCount = 0;
    [SerializeField] private bool run;
    [SerializeField] private bool runFastest;
    [SerializeField] private bool fall;
    [SerializeField] private bool doubleJump;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Se o raio do groundCheckpoint do player estiver colidindo com a 
        // layer ground, a variável receberá true
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (isGrounded) jumpCount = 0;

        xInput = Input.GetAxis("Horizontal");
        ySpeed = rb.velocity.y;

        if (xInput != 0) idle = false;
        else idle = true;

        if (xInput < 0)
        {
            transform.localScale = new Vector3(-1f,transform.localScale.y,transform.localScale.z);
        }
        else if (xInput > 0) 
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }

        activeSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            activeSpeed = runSpeed;
            runFastest = true;
        }else runFastest = false;

        rb.velocity = new Vector2(xInput * activeSpeed, rb.velocity.y);
        
        
        bool yInput = Input.GetButtonDown("Jump");
        if(yInput)
        {
            // Se está no chão
            if (isGrounded)
            {
                // Pula e habilita doubleJump
                Jump();
                canDoubleJump = true;
            }
            else
            {
                // Se puder usar o double jump
                if (canDoubleJump)
                {
                    // Pula novamente e desativa o double jump
                    Jump();
                    canDoubleJump= false;
                }
            }
        }
        SetAnimations();
    }

    private void Jump()
    {
        jumpCount++;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void SetAnimations()
    {
        animator.SetBool("idle", idle);
        animator.SetFloat("speed", Mathf.Abs(xInput));
        animator.SetBool("runFastest", runFastest);
        animator.SetFloat("ySpeed", Mathf.Abs(ySpeed));
        animator.SetInteger("jumpCount", jumpCount);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.SetTrigger("hit");
        }
    }
}
