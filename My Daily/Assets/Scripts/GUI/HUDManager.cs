using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject pausedPanel;

    public void OnClickPausedButton()
    {
        Time.timeScale = 0;
        pausedPanel.SetActive(true);
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        pausedPanel.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
