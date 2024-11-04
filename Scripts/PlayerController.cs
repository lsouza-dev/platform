using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Components")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Player Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float activeSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
    // Mascara de layer que será usada para verificar a colisão
    // entre os objetos
    [SerializeField] private LayerMask whatIsGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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

        float xInput = Input.GetAxis("Horizontal");

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

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
