using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource enemyDeathSound;
    [SerializeField] private List<Transform> points;
    private float speed = 1f;

    private Animator anim;
    private int currentIndex;
    private Vector2 currentPoint;
    private bool walking;
    private bool isDead;
    private int hitCount;
    private int hits = 0;
    private bool attacking;
    public void Hit()
    {
        if (hitCount < 2)
        {
            anim.Play("hurt");
            hitCount++;
<<<<<<< HEAD:Assets/Enemy.cs
=======
            hitSound.Play();
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Enemy.cs
        }
        else
        {
            isDead = true;
            anim.SetBool("walk", false);
            anim.Play("dead");
            enemyDeathSound.Play();
            Destroy(GetComponent<Collider2D>(), 1);
            Destroy(GetComponent<Rigidbody2D>(), 1);
            Destroy(this, 2);
<<<<<<< HEAD:Assets/Enemy.cs
=======
            
>>>>>>> b9ba6fe473ee6686aee292c0c606fb59d0886d60:Assets/scripts/Enemy.cs

           // Destroy(gameObject);
        }
        
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        currentPoint = points[0].position;
        walking = true;
        ChooseDirection();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (attacking)
            anim.Play("attack");
        Walk();
    }

    private void Walk()
    {
        anim.SetBool("walk", walking);
        if (!walking) return;
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, currentPoint, step);
        if (Vector3.Distance(transform.position, currentPoint) < 0.3f)
        {
            StartCoroutine(Idle());
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            attacking = true;
            if (hits < 3)
            {
                hits++;
            }
            else
            {
                coll.gameObject.GetComponent<Movement>().Dead();
                attacking = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        attacking = false;
    }

    private IEnumerator Idle()
    {
        walking = false;
        anim.SetTrigger("idle");
        ChooseNextPoint();
        yield return new WaitForSeconds(1);
        walking = true;
    }

    private void ChooseNextPoint()
    {
        currentIndex = ++currentIndex < points.Count ? currentIndex : 0;
        currentPoint = points[currentIndex].position;
        ChooseDirection();
    }

    private void ChooseDirection()
    {
        GetComponent<SpriteRenderer>().flipX = currentPoint.x < transform.position.x;
    }
}
