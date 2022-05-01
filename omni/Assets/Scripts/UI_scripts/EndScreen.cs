using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Loading Main Menu...");
        SceneManager.LoadScene("scene_mainmenu");
    }

    public void LoadHub()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Loading Hub...");
        SceneManager.LoadScene("scene_hub");
    }

    public void LoadHubPortal()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("Loading Hub...");
        SceneManager.LoadScene("scene_hub_PORTAL");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
