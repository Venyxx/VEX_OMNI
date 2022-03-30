using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class script_lantern : MonoBehaviour
{

    public int darknessDisplay;
    public TextMeshProUGUI darknessGUI;
    public TextMeshProUGUI overHeadLantern;
    public float waitTime = 1.0f;
    public float lanternWaitTime = 10f;
    public float darknessWaitTime = 3f;

    private script_character_movement playerScriptAccess;
    public bool lanternIsLit = false;
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
            darknessChecking();
            //Debug.Log(isSafe);
        }
        else if (isSafe == true)
        {
            hasDarkness = false;
        }

        if (lanternTimeRunner)
        {
            lanternWaitTime -= Time.deltaTime;
            //Debug.Log("the lantern is depleting" + lanternWaitTime);
            if (lanternWaitTime < 0)
            {
                lanternIsLit = false;
                lanternTimeRunner = false;
                Debug.Log("the lantern turned off");
                lanternWaitTime = 18;
            }
        }



        //DISPLAY FOR ITS ON OR NO DEV BUILD----------------------------

        if (overHeadLantern != null)
        {
            if (lanternIsLit)
            {
                overHeadLantern.text = "Active";
            }
            else
                overHeadLantern.text = "Inactive";

        }

    }

    void OntriggerEnter(Collider other)
    {
        Debug.Log("lantern light detecting");
        Debug.Log("light rounds" + playerScriptAccess.hasLightRounds);
        Debug.Log("safety " + isSafe);
        Debug.Log("darkness  " + hasDarkness);
        if (other.tag == "Player" && lanternIsLit == true)
        {
            hasDarkness = false;
            isSafe = true;
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && lanternIsLit == true)
        {
            playerScriptAccess.hasLightRounds = true;
            hasDarkness = false;
            //Debug.Log("has darkness " + hasDarkness);
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
                    waitTime = 1.0f;
                }


            }
        }
        else
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

        //this is if the lantern was previously off--------------
        if (playerScriptAccess.hasLightRounds && lanternIsLit == false && collision.collider.CompareTag("Arrow"))
        {
            Debug.Log("this lanter was off and now it is turning on");
            playerScriptAccess.holdingLight = false;
            Debug.Log("boolHoldingLightChar in Hands" + playerScriptAccess.holdingLight);
            lanternIsLit = true;
            lanternChecking();
        }

        if (playerScriptAccess.holdingLight && collision.collider.CompareTag("Arrow"))
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

            playerScriptAccess.hasLightRounds = false;
            Debug.Log("has light rounds" + playerScriptAccess.hasLightRounds);
            isSafe = false;
            hasDarkness = true;
        }

    }

    void lanternChecking()
    {

        lanternTimeRunner = true;
    }

    void darknessChecking()
    {
        //Debug.Log("darkness checking called");
        if (darknessWaitTime > 0 && hasDarkness == true && isSafe == false)
        {
            //Debug.Log("passed test, wait time : has dark : is safe " + darknessWaitTime + hasDarkness + isSafe);
            darknessWaitTime -= Time.deltaTime;

        }
        else if (darknessWaitTime < 0)
        {
            playerScriptAccess.weightOfDarkness++;
            darknessWaitTime = 3f;
            Debug.Log("added one to weight of darkness");
        }

    }
}
