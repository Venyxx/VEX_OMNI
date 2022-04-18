using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_boss_cyl : MonoBehaviour
{
    // Start is called before the first frame update
   // public bool hasSol;
    private script_character_movement script_character_Movement;
    //public float solCurrent;
   // public float solMax = 6f;
    // public int solDisplay;
    //public TextMeshProUGUI solGUI;
    private script_brilliance script_Brilliance;
    private script_gaze_manager gazeAccess;

    void Start()
    {
         GameObject player = GameObject.FindGameObjectWithTag("Player");
         GameObject manager = GameObject.Find("GAZEMANAGER");
        script_character_Movement = player.GetComponent<script_character_movement>();
        script_Brilliance = manager.GetComponent<script_brilliance>();
        gazeAccess = manager.GetComponent<script_gaze_manager>();
        Debug.Log("cylspawn");

    }


    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerStay (Collider collider)
    {
        if (collider.tag == "Player")
        {
            gazeAccess.hasGaze = false;
            script_character_Movement.hasLightRounds = true;
            Debug.Log("noticed player");
        }
    }

    void OnTriggerExit (Collider collider)
    {
        gazeAccess.hasGaze = true;
        script_character_Movement.hasLightRounds = false;
        Debug.Log ("left");
    }
    
    
}
