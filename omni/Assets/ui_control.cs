using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_control : MonoBehaviour
{
    // Start is called before the first frame update
    // when audio is implemented can deafen with function 
    public static bool PauseGame = false;

    public GameObject pauseUI;
    public GameObject reticle;

    // Update is called once per frame
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
        Debug.Log("called resume");
        Cursor.lockState = CursorLockMode.Locked;
        //time scale was 0? -v
        pauseUI.SetActive(false);
        reticle.SetActive(true);
        Time.timeScale = 1f;
        PauseGame = false;
        AudioListener.pause = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        reticle.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
        AudioListener.pause = true;
    }
    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("scene_mainmenu");
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("you are quitten");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("scene_eclipse");
    }
}
