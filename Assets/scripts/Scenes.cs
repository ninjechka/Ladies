using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [SerializeField] public Button level2;
    [SerializeField] public Button level3;
    private int levelComplete;

    public void ChooseScenes(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void Exit()
    {
        Application.Quit();
    }
    void Start()
    {
        levelComplete = PlayerPrefs.GetInt("Levels");
        level2.interactable = false;
        level3.interactable = false;
        switch (levelComplete)
        {
            case 1:
                level2.interactable = true;
                break;
            case 2:
                level2.interactable = true;
                level3.interactable = true;
                break;
        }
    }

    void Update()
    {
        
    }
}
