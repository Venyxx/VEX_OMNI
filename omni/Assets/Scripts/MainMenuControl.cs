using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
   public void GameStart ()
   {
     SceneManager.LoadScene("Scene_maze");
   }
//     public void CreditsMenu ()
//    {
//     SceneManager.LoadScene("Credits");
//    }
public void ExitGame ()
{
    Debug.Log("You quitter");
    Application.Quit();
}
}
