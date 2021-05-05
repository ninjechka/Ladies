using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HeartsPlayer.numOfHearts == 3) return;
            HeartsPlayer.numOfHearts += 1;
            Destroy(gameObject);
        }
    }
}