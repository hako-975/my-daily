using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject pausedPanel;
    public AudioSource musicBGM;

    public GameObject mainCam;
    public GameObject player;
    public GameObject thirdPersonCam;

    public GameObject flyCam;

    public GameObject droneButton;
    public GameObject exitDroneButton;

    public GameObject joystick;
    public GameObject joystickDrone;

    private bool isPaused = false;

    void Start()
    {
        droneButton.SetActive(true);
        exitDroneButton.SetActive(false);

        joystick.SetActive(true);
        joystickDrone.SetActive(false);
    }

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

    public void OnClickDroneModeButton()
    {
        joystick.SetActive(false);
        joystickDrone.SetActive(true);

        droneButton.SetActive(false);
        mainCam.SetActive(false);
        player.SetActive(false);
        thirdPersonCam.SetActive(false);

        flyCam.SetActive(true);
        exitDroneButton.SetActive(true);
    }

    public void OnClickExitDroneModeButton()
    {
        joystick.SetActive(true);
        joystickDrone.SetActive(false);

        exitDroneButton.SetActive(false);
        mainCam.SetActive(true);
        player.SetActive(true);
        thirdPersonCam.SetActive(true);

        flyCam.SetActive(false);
        droneButton.SetActive(true);
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
