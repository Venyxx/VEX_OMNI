using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuControl : MonoBehaviour
{

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameStart ()
   {
    SceneManager.LoadScene("scene_hub_CUTSCENE");
   }
    
public void ExitGame ()
{
    Debug.Log("Quitter");
    Application.Quit();
}

}
