using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
public class UI_Control : MonoBehaviour
{
    public GameObject pauseUI;
    private StarterAssetsInputs starterAssetsInputs;
    public static bool PauseGame = false;

    

    void Start ()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    void Update()
    {
        if (starterAssetsInputs.escape)
        {
            Debug.Log("internal notice esc");
            if (PauseGame)
            {
                Resume();
            }
            
        }else
            {
                Pause();
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
        SceneManager.LoadScene("scene_mainmenu");
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Quitter");
        Application.Quit();
    }
}
