using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_lantern_boss : MonoBehaviour
{
    public int gazeDisplay;
    public TextMeshProUGUI gazeGUI;
    //public float waitTime = 1.0f;
    //public float lanternWaitTime = 10f;
    //public float darknessWaitTime = 3f;
    public script_character_movement script_character_Movement;
    public bool lanternIsLit = false;
    public bool hasGaze = false;
    public bool isSafe = true;
    //bool lanternTimeRunner = false;
    public GameObject particleEffect;
    public bool firstLantern;
    public float gazeMax = 16f;
    public float gazeCurrent;

    
    //public Transform particleSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gazeDisplayMethod();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        script_character_Movement = player.GetComponent<script_character_movement>();
        particleEffect.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        gazeChecking();
        gazeDisplayMethod();
        if (gazeCurrent <= 0 && hasGaze)
        {
            Debug.Log("death, reset");
        }

        if (isSafe == false)
        {

            //Debug.Log(isSafe);
        }

        else if (isSafe == true)
        {
            hasGaze = false;
        }


        //DISPLAY FOR ITS ON OR NO DEV BUILD----------------------------
    }

    void OntriggerEnter(Collider other)
    {
        /*Debug.Log("lantern light detecting");
        Debug.Log("light rounds" + script_character_Movement.hasLightRounds);
        Debug.Log("safety " + isSafe);
        Debug.Log("darkness  " + hasDarkness);*/
        if (other.tag == "Player" && lanternIsLit == true)
        {
            //INSERT SOUND CLIP FOR GETTING LIGHT HERE
            script_character_Movement.firstPickLight = false;
            hasGaze = false;
            isSafe = true;
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && lanternIsLit == true)
        {
            script_character_Movement.hasLightRounds = true;
            hasGaze = false;
            //Debug.Log("has darkness " + hasDarkness);
            isSafe = true;
            //Debug.Log("can shoot light damage" + script_character_Movement.hasLightRounds);

            //neeeds to start counting down----

        }
        else if (other.tag == "Player" && lanternIsLit == false)
            script_character_Movement.hasLightRounds = false;
    }
    void gazeDisplayMethod()
    {


        if (hasGaze)
        {
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

    void OnCollisionEnter(Collision collision)
    {
        //GameObject other = collision.gameObject;

        //this is if the lantern was previously off--------------
        if (script_character_Movement.hasLightRounds && lanternIsLit == false && collision.collider.CompareTag("Arrow"))
        {
            Debug.Log("this lanter was off and now it is turning on");
            particleEffect.SetActive(true);  
            script_character_Movement.holdingLight = false;
            // Debug.Log("boolHoldingLightChar in Hands" + script_character_Movement.holdingLight);
            lanternIsLit = true;
            Destroy(collision.gameObject);
        }

        if (script_character_Movement.holdingLight && collision.collider.CompareTag("Arrow"))
        {
            particleEffect.SetActive(true);
            Debug.Log("ran particle");
            script_character_Movement.holdingLight = false;
            lanternIsLit = true;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //INSERT SOUND CLIP FOR LOSING LIGHT HERE
            script_character_Movement.hasLightRounds = false;
            Debug.Log("getting gaze");
            isSafe = false;
            hasGaze = true;
            gazeCurrent = gazeMax;
        }
    }



    void gazeChecking()
    {
        if (hasGaze)
        {
            if (script_character_Movement.hasLightRounds == false && firstLantern)
            {
                gazeCurrent -= Time.deltaTime;
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