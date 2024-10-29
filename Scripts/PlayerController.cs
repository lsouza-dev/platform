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
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius;
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
        float xInput = Input.GetAxis("Horizontal");

        activeSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftControl)) activeSpeed = runSpeed;
        rb.velocity = new Vector2(xInput * activeSpeed, rb.velocity.y);
        
        
        bool yInput = Input.GetButtonDown("Jump");
        if(yInput) rb.velocity = new Vector2 (rb.velocity.x, jumpForce);

    }

}
