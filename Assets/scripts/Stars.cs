using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    [SerializeField] public Image stars;
    [SerializeField] private Sprite[] diffStars;
    private int level;
    private int records;
    void Start()
    {
        level = PlayerPrefs.GetInt("LastLevel");
        records = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyText.key != 3) return;
        var record = CoinsPlayer.money;
        if (record == 0) stars.sprite = diffStars[0];
        if (record > 45)
        {
            stars.sprite = diffStars[3];
            records = 3;
        }
        else if (record > 30)
        {
            stars.sprite = diffStars[2];
            records = 2;
        }
        else if (record > 0)
        {
            stars.sprite = diffStars[1];
            records = 1;
        }
        if (PlayerPrefs.GetInt($"Level{level}") <= records)
        PlayerPrefs.SetInt($"Level{level}", records);
    }
}
