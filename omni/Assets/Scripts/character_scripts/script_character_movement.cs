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


    public float weightOfDarkness = 0;


    // Update is called once per frame

    void Start()
    {
        weightOfDarkness = 0;
    }
    void Update()
    {


        //light rounds gui---------------------
        if (hasLightRounds)
        {
            lightRoundDisplay.text = "Light Rounds";
            Debug.Log("has light");
        }
        else
        {
             if (lightRoundDisplay != null)
            lightRoundDisplay.text = "";
            Debug.Log("no light");

        }
           
        
        if (weightOfDarkness >= 10)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

}