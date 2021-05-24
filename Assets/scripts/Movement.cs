using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD:Assets/Movement.cs
=======
using UnityEngine.SceneManagement;
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Movement.cs
using UnityEngine.XR.WSA.Persistence;

public class Movement : MonoBehaviour
{
    public float hangTime = .2f;
<<<<<<< HEAD:Assets/Movement.cs
=======
    public AudioSource damageSound;
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Movement.cs
    private float hangCounter;
    private float speed = 2f;
    private float jumpForce = 4f;
    private Animator anim;
    private Rigidbody2D rb2D;
    private SpriteRenderer sprite;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    private bool canJump;
    private bool canWallJump;
    private bool onWall;
    private bool first = true;
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
<<<<<<< HEAD:Assets/Movement.cs
=======
        if (isDead)
            SceneManager.LoadScene("Lose");
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Movement.cs
        if (isGrounded)
            hangCounter = hangTime;
        else hangCounter -= Time.deltaTime;

        if (isGrounded || canWallJump)
            canJump = true;
        else canJump = false;

        if (isGrounded)
            first = true;
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
        if (Input.GetKey("space") && (hangCounter >= 0.0f || (first && canJump)))
        {
            Jump();
        }
        if (Input.GetKey("w") || Input.GetKey("up") && canJump)
            Ledge();

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
        if (isDead)
        { return; }
        isDead = true;
<<<<<<< HEAD:Assets/Movement.cs
        Destroy(GetComponent<Collider2D>(), 1);
        Destroy(GetComponent<Rigidbody2D>(), 1);
        Destroy(this, 2);
        Destroy(gameObject);

=======
        SceneManager.LoadScene("Lose");
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Movement.cs
        // anim.Play("dead");
    }
    public void GetDamage()
    {
<<<<<<< HEAD:Assets/Movement.cs
        
        HeartsPlayer.numOfHearts -=1;
=======
        HeartsPlayer.numOfHearts -=1;
        damageSound.Play();
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Movement.cs
        anim.Play("hurt");
    }

    private void Ledge()
    {
        if (!onWall) return;
        rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        anim.Play("ledge");
    }

    private void Jump()
    {
        if (onWall)
            first = false;
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        anim.Play("jump");
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
        if (coll.gameObject.tag.Equals("Wall") && !isGrounded)
        {
            onWall = false;
            canWallJump = false;
        }
    }
}
