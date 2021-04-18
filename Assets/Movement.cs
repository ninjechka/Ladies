using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2f;
    private float jumpForce = 5f;
    private Animator anim;
    private Rigidbody2D rb2D;
    private SpriteRenderer sprite;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    private bool canJump;
    private bool canWallJump;
    private bool onWall;
    private bool first = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isGrounded || canWallJump)
            canJump = true;
        else canJump = false;
        if (isGrounded)
            first = true;
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else isGrounded = false;

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            if (isGrounded)
                anim.Play("run");
            sprite.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            if (isGrounded)
                anim.Play("run");
            sprite.flipX = true;
        }
        else
        {
            if (isGrounded)
                anim.Play("idle");
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        ;
        if (Input.GetKey("space") && (isGrounded || (first && canJump)))
        {
            Jump();
        }

        if (Input.GetKey("w") || Input.GetKey("up") && canJump)
            Lending();
    }

    private void Lending()
    {
        if (!onWall) return;
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        anim.Play("ledge");
    }

    private void Jump()
    {
        if (onWall)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            anim.Play("jump");
            first = false;
        }
        else
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            anim.Play("jump");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Wall"))
        {
            onWall = true;
            canWallJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Wall"))
        {
            onWall = false;
            canWallJump = false;
        }
    }
}
