using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    [SerializeField] public Image stars;
    [SerializeField] private Sprite[] diffStars;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyText.key != 3) return;
        var record = CoinsPlayer.money;
        if (record == 0) stars.sprite = diffStars[0];
        if (record > 45)
            stars.sprite = diffStars[3];
        else if (record > 30)
            stars.sprite = diffStars[2];
        else if (record > 0)
            stars.sprite = diffStars[1];
    }
}
