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
            //Debug.Log(isSafe);
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
            isSafe = true;
            //Debug.Log("can shoot light damage" + playerScriptAccess.hasLightRounds);

            //neeeds to start counting down----
            if (playerScriptAccess.weightOfDarkness > 0)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    //Debug.Log(waitTime);
                }

                if (waitTime <= 0)
                {
                    playerScriptAccess.weightOfDarkness -= 1;
                    waitTime = 1.5f;
                }


            }
        }else
        playerScriptAccess.hasLightRounds = false;
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
        Debug.Log("lantern hit");
        Debug.Log("light rounds"  + playerScriptAccess.hasLightRounds);
        Debug.Log("lantern is lit " + lanternIsLit);
        Debug.Log("Collision object tag "+collision.collider.tag);
        //this is if the lantern was previously off--------------
        if (playerScriptAccess.hasLightRounds && lanternIsLit == false && collision.collider.CompareTag("Arrow")) 
        {
            Debug.Log("this lanter was off and now it is turning on");
            playerScriptAccess.holdingLight = false;
            Debug.Log("boolHoldingLightChar in Hands" + playerScriptAccess.holdingLight);
            lanternIsLit = true;
            lanternChecking();
        }

        if(playerScriptAccess.holdingLight && collision.collider.CompareTag("Arrow"))
        {
            playerScriptAccess.holdingLight = false;
            lanternIsLit = true;
            lanternChecking();
        }

    
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasDarkness = true;
            playerScriptAccess.hasLightRounds = false;
            Debug.Log("has light rounds" + playerScriptAccess.hasLightRounds);
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
