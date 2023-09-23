using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSoundEffect;
    private BoxCollider2D coll;
    private SpriteRenderer spriteRenderer;
    private float dirX = 0f;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private LayerMask jumpableGround;
    
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [Header("Wall Jump System")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;
    public float wallJumpDuration;
    public Vector2 wallJumpForce;
    bool wallJumping;

    private enum MovementState {idle , running , jumping, falling }  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.2f,1.7f),0,jumpableGround);
        if (isWallTouch && !IsGrounded() && dirX!= 0)
        {
            isSliding = true;
        }
        else 
        {
            isSliding = false;
        }
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(-dirX * wallJumpForce.x , wallJumpForce.y);
        }
        else
        {
            rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else if (dirX <0)
        {
           state = MovementState.running;
           transform.localScale = new Vector3(-1f,1f,1f);
        }
        else 
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state",(int) state);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        }
        else if (isSliding)
        {
            wallJumping = true;
            Invoke(nameof(StopWallJump), wallJumpDuration); 
        }
    }

    private void StopWallJump()
    {
        wallJumping = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,  jumpableGround);
    }
}
