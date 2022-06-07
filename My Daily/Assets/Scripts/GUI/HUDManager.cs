using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject pausedPanel;
    public AudioSource musicBGM;

    private bool isPaused = false;

    public void OnClickPausedButton()
    {
        isPaused = true;
        Time.timeScale = 0;
        musicBGM.volume = 0;
        musicBGM.Pause();

        if (musicBGM.time > 2f)
        {
            musicBGM.time -= 2f;
        }

        pausedPanel.SetActive(true);
    }

    public void OnClickResumeButton()
    {
        isPaused = false;
        Time.timeScale = 1;
        musicBGM.Play();
        musicBGM.volume = 1;
        pausedPanel.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        isPaused = false;
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                OnClickResumeButton();
            }
            else
            {
                OnClickPausedButton();
            }
        }
    }
}
