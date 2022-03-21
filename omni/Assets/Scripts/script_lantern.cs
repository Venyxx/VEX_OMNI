using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class script_lantern : MonoBehaviour
{
    
    public int darknessDisplay;
    public TextMeshProUGUI darknessGUI;
    public float waitTime = 1.5f;
    public float lanternWaitTime = 10f;
     public float darknessWaitTime = 1.0f;
    public script_character_movement boolHoldingLightChar;
    public script_character_movement boolHoldingLightRoundsChar;
    public script_character_movement playerScriptAccess;
    bool lanternIsLit = false;
    public bool hasDarkness = false;
    public bool isSafe = true;
    // Start is called before the first frame update
    void Start()
    {
        darknessDisplayMethod();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScriptAccess = player.GetComponent<script_character_movement>();
        boolHoldingLightChar = player.GetComponent<script_character_movement>();
        boolHoldingLightRoundsChar = player.GetComponent<script_character_movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        darknessDisplayMethod();
        if (playerScriptAccess.weightOfDarkness >= 10)
        {
            Debug.Log("death, reset");
        }

    if (isSafe == false)
    {
        playerScriptAccess.weightOfDarkness += Time.deltaTime;
        Debug.Log(isSafe);
    }

    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("noticed lantern");
        if (other.tag == "Player" && lanternIsLit == true)
        {
            boolHoldingLightRoundsChar.hasLightRounds = true;
            Debug.Log("boolHoldingLightRoundsChar" + boolHoldingLightRoundsChar);

            //neeeds to start counting down----
            if (playerScriptAccess.weightOfDarkness > 0)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    Debug.Log(waitTime);
                }
                
                if (waitTime <= 0)
                {
                    playerScriptAccess.weightOfDarkness -= 1;
                    waitTime = 1.5f;
                }


            }
        }
    }
    void darknessDisplayMethod()
    {

        darknessDisplay = (int)playerScriptAccess.weightOfDarkness;
        if (playerScriptAccess.weightOfDarkness <= 0)
        {
            darknessGUI.text = "";
        }else
        darknessGUI.text = "SOMBRE x" + darknessDisplay.ToString();
    }

    void OnCollisionEnter (Collision collision)
    {
        GameObject other = collision.gameObject;
        isSafe = true;
        //this is if the lantern was previously off--------------
        if (other.tag == "LightRound" && lanternIsLit == false)
        {
            
            boolHoldingLightChar.holdingLight = false;
            Debug.Log("boolHoldingLightChar in Hands" + boolHoldingLightChar);
            lanternIsLit = true;
            lanternChecking();
        }
        else if (other.tag == "LightRound" && lanternIsLit == true)
        {
            //you are picking up the light---------------------
            boolHoldingLightChar.holdingLight = true;
            Debug.Log("boolHoldingLightChar in Hands" + boolHoldingLightChar);
            lanternIsLit = false;
        }
    }

    void OnCollisionExit ()
    {
        hasDarkness = true;
        isSafe = false;

    }

    void lanternChecking ()
    {
        lanternWaitTime -= Time.deltaTime;
        if (lanternWaitTime == 0)
        {
            lanternIsLit = false;
            Debug.Log("the lantern turned off");
        }
    }

    void darknessChecking ()
    {
        
        if (darknessWaitTime > 0)
                {
                    darknessWaitTime -= Time.deltaTime;
                    
                    playerScriptAccess.weightOfDarkness ++;
                    Debug.Log("added one to weight of darkness");
                    
                }
                
                if (waitTime <= 0)
                {
                    playerScriptAccess.weightOfDarkness -= 1;
                    darknessWaitTime = 1.0f;
                }
    }
}
