using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;

public class ui_control : MonoBehaviour
{
    // Start is called before the first frame update
    // when audio is implemented can deafen with function 
    public static bool PauseGame = false;

    public GameObject pauseUI;
    public GameObject reticle;
    public StarterAssetsInputs starterAssetsInputs;
    void Start ()
    {
        //starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
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

    public void RestartEclipse()
    {
        SceneManager.LoadScene("scene_eclipse");
    }

    public void RestartSolstice()
    {
        SceneManager.LoadScene("scene_solstice");
    }

    public void RestartBoss()
    {
        SceneManager.LoadScene("scene_boss");
    }

    public void LoadHub()
    {
        SceneManager.LoadScene("scene_hub");
    }
}
