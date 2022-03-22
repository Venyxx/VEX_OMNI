using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class script_lantern : MonoBehaviour
{

    public int darknessDisplay;
    public TextMeshProUGUI darknessGUI;
    public TextMeshProUGUI overHeadLantern;
    public float waitTime = 1.5f;
    public float lanternWaitTime = 10f;
    public float darknessWaitTime = 1.0f;

    public script_character_movement playerScriptAccess;
    bool lanternIsLit = false;
    public bool hasDarkness = false;
    public bool isSafe = true;
    bool lanternTimeRunner = false;

    
    // Start is called before the first frame update
    void Start()
    {
        darknessDisplayMethod();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScriptAccess = player.GetComponent<script_character_movement>();


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

        if(lanternTimeRunner)
        {
            lanternWaitTime -= Time.deltaTime;
        //Debug.Log("the lantern is depleting" + lanternWaitTime);
        if (lanternWaitTime < 0)
        {
            lanternIsLit = false;
            lanternTimeRunner = false;
            Debug.Log("the lantern turned off");
            lanternWaitTime = 10;
        }
        }



        //DISPLAY FOR ITS ON OR NO DEV BUILD----------------------------
        if(lanternIsLit)
        {
            overHeadLantern.text = "Active";
        }
        else
        overHeadLantern.text = "Inactive";

    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && lanternIsLit == true)
        {
            playerScriptAccess.hasLightRounds = true;
            Debug.Log("can shoot light damage" + playerScriptAccess.hasLightRounds);

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
        }
        else
            darknessGUI.text = "SOMBRE x" + darknessDisplay.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        //GameObject other = collision.gameObject;

        //this is if the lantern was previously off--------------
        if (collision.collider.CompareTag("LightRound") && lanternIsLit == false)
        {
            Debug.Log("this lanter was off and now it is turning on");
            playerScriptAccess.holdingLight = false;
            Debug.Log("boolHoldingLightChar in Hands" + playerScriptAccess.holdingLight);
            lanternIsLit = true;
            lanternChecking();
        }
        else if (collision.collider.CompareTag("LightRound") && lanternIsLit == true)
        {
            Debug.Log("this lanter was on and now it is turning off");
            //you are picking up the light---------------------
            playerScriptAccess.holdingLight = true;
            Debug.Log("boolHoldingLightChar in Hands" + playerScriptAccess.holdingLight);
            lanternIsLit = false;

        }


        if (collision.collider.CompareTag("Arrow") && playerScriptAccess.holdingLight == true)
        {
            Debug.Log("noticed light, turning on lantern");
            lanternIsLit = true;
            playerScriptAccess.holdingLight = false;
            lanternChecking();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hasDarkness = true;
            isSafe = false;
        }



    }

    void lanternChecking()
    {
        
        lanternTimeRunner = true;
    }

    void darknessChecking()
    {

        if (darknessWaitTime > 0)
        {
            darknessWaitTime -= Time.deltaTime;

            playerScriptAccess.weightOfDarkness++;
            Debug.Log("added one to weight of darkness");

        }

        if (waitTime <= 0)
        {
            playerScriptAccess.weightOfDarkness -= 1;
            darknessWaitTime = 1.0f;
        }
    }
}
