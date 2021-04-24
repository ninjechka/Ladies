using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag.Equals("Enemy"))
        {
            coll.GetComponent<Enemy>().Hit();
            var playerBody = player.GetComponent<Rigidbody2D>();
            playerBody.velocity = new Vector2(playerBody.velocity.x, 3);
        }
    }
}
