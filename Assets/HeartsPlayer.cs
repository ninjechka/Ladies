using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsPlayer : MonoBehaviour
{
    public float health;
    public static int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        numOfHearts = 3;
        if (health > numOfHearts)
            health = numOfHearts;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
                hearts[i].sprite = emptyHeart;
            else hearts[i].sprite = fullHeart;
            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
