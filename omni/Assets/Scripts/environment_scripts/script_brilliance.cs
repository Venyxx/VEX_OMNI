using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class script_brilliance : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasSol;
    private script_character_movement script_character_Movement;
    
    public float solCurrent;
    public float solMax = 6f;
     public int solDisplay;
    public TextMeshProUGUI solGUI;
    void Start()
    {
        
         GameObject player = GameObject.FindGameObjectWithTag("Player");
        script_character_Movement = player.GetComponent<script_character_movement>();
        solCurrent = solMax;
        hasSol = true;
    }

    // Update is called once per frame
    void Update()
    {
        solChecking();
        gazeDisplayMethod();

        if (solCurrent <= 0)
        {
SceneManager.LoadScene("GameOver");
        }
    }
    void solChecking()
    {
        if (hasSol)
        {
            //Debug.Log("is runnung");
            if (script_character_Movement.hasLightRounds == false)
            {
                solCurrent -= Time.deltaTime;
                Debug.Log(solCurrent);
            }
        }
        else if (hasSol == false || script_character_Movement.hasLightRounds == true)
        {
            solCurrent = solMax;
        }

        if (script_character_Movement.hasLightRounds == true)
        {
            solCurrent = solMax;
        }
    }
     void gazeDisplayMethod()
    {


        if (hasSol)
        {
            Debug.Log("noticed has gaze");
            solDisplay = (int)solCurrent;

            if (solCurrent <= 0)
            {
                solGUI.text = "";
            }
            solGUI.text = "Brilliance 0:0" + solDisplay.ToString();


        }



        if (script_character_Movement.hasLightRounds == true)
            solGUI.text = "";



    }
}
