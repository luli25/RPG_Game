using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Animator animator;

    private float xInput;
    private SpriteRenderer spriteRenderer;
    private bool isRunning;
    
    void Start()
    {
        isRunning = false;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    
    void Update()
    {
        MovePlayer();
        Jump();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if(xInput < 0)
        {
            spriteRenderer.flipX = true;

        } else if (xInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
