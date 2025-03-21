using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float groundCheckDistance;

    private float xInput;
    private bool isRunning;

    private int facingDirection = 1;
    private bool isFacingRight = true;

    [Header("Ground Check")]
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;

    void Start()
    {
        isRunning = false;
    }

    
    void Update()
    {
        MovePlayer();
        Jump();
        GroundCheck();
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void MovePlayer()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        if(rb.velocity.x != 0)
        {
            isRunning = true;

        } else
        {
            isRunning= false;
        };

        animator.SetBool("isRunning", isRunning);

        Flip();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if (xInput > 0 && !isFacingRight || xInput < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            facingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
