using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private PlayerConfig playerConfig;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float groundCheckDistance;

    private float xInput;

    private int facingDirection = 1;
    private bool isFacingRight = true;

    [Header("Ground Check")]
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;

    void Start()
    {
        
    }

    
    void Update()
    {
        MovePlayer();
        Jump();
        GroundCheck();
        AnimationController();

        playerConfig.dashTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerConfig.dashTime = playerConfig.dashDuration;
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void MovePlayer()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if ((playerConfig.dashTime > 0))
        {
            rb.velocity = new Vector2(xInput * playerConfig.dashSpeed, 0);
        } else
        {
            rb.velocity = new Vector2(xInput * playerConfig.moveSpeed, rb.velocity.y);
        }

        Flip();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * playerConfig.jumpForce, ForceMode2D.Impulse);
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

    private void AnimationController()
    {
        bool isRunning = rb.velocity.x != 0;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isDashing", playerConfig.dashTime > 0);
    }
}
