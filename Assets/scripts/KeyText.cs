using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KeyText : MonoBehaviour
{
    public static  int levelComplete = 0;
    Text text;
    public static int key;
    
    void Start()
    {
        text = GetComponent<Text>();
        key = 0;
    }
    
    void Update()
    {
        text.text = key.ToString() + "/3";
        if (key == 3)
        {
            PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Win");
            levelComplete++;
            PlayerPrefs.SetInt("Levels", levelComplete);
        }
        else PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
    }
}
