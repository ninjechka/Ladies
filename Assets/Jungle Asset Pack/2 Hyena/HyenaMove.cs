using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyenaMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 2f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 velocity;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    private void Run()
    {

        //transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = velocity.x < 0.0f;
        rb.MovePosition((Vector2)transform.position + (velocity * Time.deltaTime * speed));
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector2.right * (Time.deltaTime * 5));
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector2.left * (Time.deltaTime * 5));
        
    }
}
