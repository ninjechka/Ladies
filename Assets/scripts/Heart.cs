using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioSource heartSound;
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
            heartSound.Play();
            Destroy(gameObject);
        }
    }
}