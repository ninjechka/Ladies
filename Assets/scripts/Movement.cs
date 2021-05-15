using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float hangTime = .2f;
    public AudioSource damageSound;
    private float hangCounter;
    private float speed = 2f;
    private float jumpForce = 4f;
    private Animator anim;
    private Rigidbody2D rb2D;
    private SpriteRenderer sprite;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    public static  bool isDead;

    void Start()
    {
        isDead = false;
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isGrounded)
            hangCounter = hangTime;
        else hangCounter -= Time.deltaTime;
        if (isDead) Dead();
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position,
            1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else isGrounded = false;
        rb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb2D.velocity.y);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Run();
        }
        else if (Input.GetKey("e") && isGrounded)
        {
            anim.Play("attack");
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        else
        {
            if (isGrounded)
                anim.Play("idle");
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if (Input.GetKey("space") && hangCounter >= 0.0f)
        {
            Jump();
        }
    }

    private void Run()
    {
        if (isGrounded)
            anim.Play("run");
        var dir = transform.right * Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb2D.velocity.y);
        sprite.flipX = dir.x < 0.0f;

    }
    public void Dead()
    {
        isDead = true;
        Destroy(GetComponent<Collider2D>(), 1);
        Destroy(GetComponent<Rigidbody2D>(), 1);
        Destroy(this, 2);
        Destroy(gameObject);
        SceneManager.LoadScene("Lose");
    }
    public void GetDamage()
    {
        HeartsPlayer.numOfHearts -= 1;
        damageSound.Play();
        anim.Play("hurt");
    }


    private void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        anim.Play("jump");
    }
}
