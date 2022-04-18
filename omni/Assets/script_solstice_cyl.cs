using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_solstice_cyl : MonoBehaviour
{
    // Start is called before the first frame update
   // public bool hasSol;
    private script_character_movement script_character_Movement;
    //public float solCurrent;
   // public float solMax = 6f;
    // public int solDisplay;
    //public TextMeshProUGUI solGUI;
    private script_brilliance script_Brilliance;
    

    void Start()
    {
         GameObject player = GameObject.FindGameObjectWithTag("Player");
         GameObject brill = GameObject.FindGameObjectWithTag("BRILLHOLD");
         script_Brilliance = brill.GetComponent<script_brilliance>();
        script_character_Movement = player.GetComponent<script_character_movement>();
        
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerStay (Collider collider)
    {
        if (collider.tag == "Player")
        {
            script_Brilliance.hasSol = false;
            script_character_Movement.hasLightRounds = true;
            Debug.Log("noticed player");
        }
    }

    void OnTriggerExit (Collider collider)
    {
        script_Brilliance.hasSol = true;
        script_character_Movement.hasLightRounds = false;
        Debug.Log ("left");
    }
    
    
}
