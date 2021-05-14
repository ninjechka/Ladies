using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int levelComplete;
    private int last;
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("Levels");
        last = PlayerPrefs.GetInt("LastLevel");
    }

    public void IsEndGame()
    {
        if (last == 3)
            Invoke("LoadMainMenu", 1f);
        else
        {
            if (levelComplete < last)
                PlayerPrefs.SetInt("Levels", last);
            Invoke("NextLevel", 1f);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        if (last >= 3)
            LoadMainMenu();
        else SceneManager.LoadScene(last + 1);
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(last);
    }
}
