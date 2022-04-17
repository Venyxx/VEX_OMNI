using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class script_character_movement : MonoBehaviour
{
        //this script houses:
        //the remains of the original character controller. scripts reference this for darkness and light rounds
    public bool holdingLight = false;
    public bool hasLightRounds = false;
    public bool firstPickLight = false;
    public TextMeshProUGUI lightRoundDisplay;
    script_third_person_controller playerAccess;
    public GameObject player;



    public float weightOfDarkness = 0;


    // Update is called once per frame

    void Start()
    {
        weightOfDarkness = 0;
        playerAccess = player.GetComponent<script_third_person_controller>();        
    }
    void Update()
    {


        //light rounds gui---------------------
        if (hasLightRounds)
        {
            //lightRoundDisplay.text = "Light Rounds";
            
            
            
        }
        else
        {
             //if (lightRoundDisplay != null)
            //lightRoundDisplay.text = "";
            //Debug.Log("no light");
            

        }
        if (holdingLight)
        {
        playerAccess.bowLit = true;
        }
           
        
        if (weightOfDarkness >= 10)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

}