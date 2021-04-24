using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class KeyText : MonoBehaviour
{
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
        //if (key == 3)
            //SceneManager.LoadScene(1);
    }
}
