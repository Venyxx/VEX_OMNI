using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
public class UI_Control : MonoBehaviour
{
    public GameObject pauseUI;
    //public StarterAssetsInputs starterAssetsInputs;
    public static bool PauseGame = false;

    

    void Start ()
    {
        //starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        PauseGame = false;
        pauseUI.SetActive(false);
    }
    void Update()
    {
       
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseUI.SetActive(true);
        Time.timeScale = 0.51f;
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
