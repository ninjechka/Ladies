using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2f;
    private float jumpForce = 4.5f;
    private Animator anim;
    private Rigidbody2D rb2D;
    private SpriteRenderer sprite;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform groundCheckL;
    [SerializeField] private Transform groundCheckR;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else
        {
            isGrounded = false;
            anim.Play("jump");
        }
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

        if (Input.GetKey("space") && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            anim.Play("jump");
        }
    }

    private bool CheckGround()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
            return true;
        else return false;
    }
}
