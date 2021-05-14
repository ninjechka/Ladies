using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    [SerializeField] private Image[] stars;
    [SerializeField] private Sprite[] diffStars;

    void Start()
    {
        
    }

    void Update()
    {
        stars[0].sprite = diffStars[PlayerPrefs.GetInt("Level1")];
        stars[1].sprite = diffStars[PlayerPrefs.GetInt("Level2")];
        stars[2].sprite = diffStars[PlayerPrefs.GetInt("Level3")];
    }
}
