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
    // Mascara de layer que será usada para verificar a colisão
    // entre os objetos
    [SerializeField] private LayerMask whatIsGround;

    [Header("Player Variables")]
    [SerializeField] float xInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float activeSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private float groundCheckRadius;

    [Header("Animation Controllers")]
    [SerializeField] private bool idle;
    [SerializeField] private bool run;
    [SerializeField] private bool jump;
    [SerializeField] private bool fall;
    [SerializeField] private bool doubleJump;
    [SerializeField] private bool hit;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Se o raio do groundCheckpoint do player estiver colidindo com a 
        // layer ground, a variável receberá true
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        xInput = Input.GetAxis("Horizontal");

        if (xInput != 0) idle = false;
        else idle = true;

        activeSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl)) activeSpeed = runSpeed;
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void SetAnimations()
    {
        animator.SetFloat("speed",xInput);
        animator.SetBool("idle", idle);
        animator.SetBool("run", run);
        animator.SetBool("jump", jump);
        animator.SetBool("doubleJump", doubleJump);
        animator.SetBool("hit", hit);
    }

    private void RestartPlayerAnimations()
    {
        idle = true;
        run = false;
        jump = false;
        doubleJump = false;
        hit = false;
    }
}
