using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JaguarJak : MonoBehaviour
{
    public GameObject borealis;
    public GameObject finalCam;
    public GameObject finalTimeline;
    public GameObject thatBoy;
    public GameObject gazestop;
    [SerializeField] GameObject boss;
    scipt_boss_control scipt_boss_control;
    public Material finalsky;
    public GameObject postP;
    [SerializeField] GameObject musicCam;
public GameObject jaguars;
public GameObject lunardistortion;

   // void Start()
   // /{
         // StartCoroutine(ActivationRoutine());
   // }

void OnTriggerEnter(Collider other)
    {
    
            borealis.SetActive(false);
            finalCam.SetActive(true);
            finalTimeline.SetActive(true);
            thatBoy.SetActive(true);
    gazestop.SetActive(false);
     boss.GetComponent<scipt_boss_control>().enabled = false;
     musicCam.GetComponent<AudioSource>().enabled = false;
    RenderSettings.skybox = finalsky;
    postP.SetActive(false);
    jaguars.SetActive(true);
    lunardistortion.SetActive(true);

    
}
/*private IEnumerator ActivationRoutine()
     {  
         //Turn the Game Oject back off after x sec.
         yield return new WaitForSeconds(32);
 
        SceneManager.LoadScene("WinGame");
        
     }*/
}
