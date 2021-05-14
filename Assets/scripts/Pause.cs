using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool Paused;
    public GameObject PauseMenu;

    void Start()
    {
        Paused = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                GetPause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    private void GetPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}
