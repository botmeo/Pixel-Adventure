using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private float dirX = 0f;
    private bool isFacingRight = true;

    private enum MovementState { idle, run, jump, fall }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void CheckInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && dirX < 0)
        {
            Flip();
        } 
        else if (!isFacingRight && dirX > 0)
        {
            Flip();
        }
    }

    private void PlayerMovement()
    {
        body.velocity = new Vector2(dirX * speed, body.velocity.y);
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (IsGrounded())
        {
            if (dirX > 0f)
            {
                state = MovementState.run;
              
            }
            else if (dirX < 0f)
            {
                state = MovementState.run;
               
            }
            else
            {
                state = MovementState.idle;
            }
            animator.SetInteger("State", (int)state);
        }
        else
        {
            if (body.velocity.y > 0.1f)
            {
                state = MovementState.jump;
            }
            else 
            {
                state = MovementState.fall;
            }
            animator.SetInteger("State", (int)state);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

}
