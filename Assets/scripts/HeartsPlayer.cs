using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsPlayer : MonoBehaviour
{
    public float health = 3;
    public static int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        numOfHearts = 3;
        hearts[1].sprite = fullHeart;
        hearts[2].sprite = fullHeart;
        hearts[0].sprite = fullHeart;
    }
    
    void Update()
    {
        if (numOfHearts == 0)
            Movement.isDead = true;
        health = numOfHearts > 3 ? 3 : numOfHearts;
        switch (health)
        {
            case 3:
                hearts[1].sprite = fullHeart;
                hearts[2].sprite = fullHeart;
                hearts[0].sprite = fullHeart;
                break;
            case 2:
                hearts[1].sprite = fullHeart;
                hearts[0].sprite = fullHeart;
                hearts[2].sprite = emptyHeart;
                break;
            case 1:
                hearts[0].sprite = fullHeart;
                hearts[1].sprite = emptyHeart;
                hearts[2].sprite = emptyHeart;
                break;
            case 0:
                hearts[1].sprite = emptyHeart;
                hearts[2].sprite = emptyHeart;
                hearts[0].sprite = emptyHeart;
                break;
                
        }
    }

    void FixedUpdate()
    {
        
        
    }
}
