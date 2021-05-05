using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    public Image rating;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rating = Stars.stars;
    }
}
