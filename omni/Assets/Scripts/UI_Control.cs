using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_Control : MonoBehaviour
{
    public static bool PauseGame = false;

    public GameObject pauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
       Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }
    public void Home()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Scene_Home");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("You quitter");
        Application.Quit();
    }
}
