using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class damageBox : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = transform.parent.gameObject;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag.Equals("Enemy"))
        {
            var playerBody = player.GetComponent<Rigidbody2D>();
            player.GetComponent<Movement>().GetDamage();
            playerBody.velocity = new Vector2(playerBody.velocity.x * 2f, 4f);
        }
    }
}
