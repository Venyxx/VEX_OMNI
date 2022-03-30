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

    public bool holdingLight = false;
    public bool hasLightRounds = false;
    public TextMeshProUGUI lightRoundDisplay;


    public float weightOfDarkness = 0;


    // Update is called once per frame

    void Start()
    {
        
    }
    void Update()
    {


        //light rounds gui---------------------
        if (hasLightRounds)
        {
            lightRoundDisplay.text = "Light Rounds";
        }
        else
            lightRoundDisplay.text = "";

        if (weightOfDarkness >= 10)
        {
            SceneManager.LoadScene("scene_maze");
        }








    }
}