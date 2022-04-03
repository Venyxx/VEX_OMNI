using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuControl : MonoBehaviour
{
   public void GameStart ()
   {
SceneManager.LoadScene("scene_vs_eclipse");
   }
    
public void ExitGame ()
{
    Debug.Log("Quitter");
    Application.Quit();
}
}
