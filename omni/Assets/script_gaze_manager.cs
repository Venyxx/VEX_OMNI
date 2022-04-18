using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_gaze_manager : MonoBehaviour
{
    // Start is called before the first frame update

    public float gazeMax = 16f;
    public float gazeCurrent;
    public bool hasGaze = false;
    public int gazeDisplay;
    public TextMeshProUGUI gazeGUI;
    public script_character_movement script_character_Movement;

    void Start()
    {
        gazeChecking();
        gazeDisplayMethod();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        script_character_Movement = player.GetComponent<script_character_movement>();

        hasGaze = true;
        script_character_Movement.hasLightRounds = false;

    }

    // Update is called once per frame
    void Update()
    {
        gazeChecking();
        gazeDisplayMethod();
    }
    void gazeDisplayMethod()
    {

        //Debug.Log("gazedisplay");
        if (hasGaze)
        {
            Debug.Log("noticed has gaze");
            gazeDisplay = (int)gazeCurrent;

            if (gazeCurrent <= 0)
            {
                gazeGUI.text = "";
            }
            gazeGUI.text = "God's Gaze 0:" + gazeDisplay.ToString();


        }



        if (script_character_Movement.hasLightRounds == true)
            gazeGUI.text = "";



    }
     void gazeChecking()
    {
        //Debug.Log("gaze checking");
        if (hasGaze)
        {
            gazeCurrent -= Time.deltaTime;
                Debug.Log(gazeCurrent);
            Debug.Log("is running");
            if (script_character_Movement.hasLightRounds == false)
            {
                
            }
        }
        else if (hasGaze == false || script_character_Movement.hasLightRounds == true)
        {
            gazeCurrent = gazeMax;
        }

        if (script_character_Movement.hasLightRounds == true)
        {
            gazeCurrent = gazeMax;
        }
    }

}
