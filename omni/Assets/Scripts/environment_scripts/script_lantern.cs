using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_lantern : MonoBehaviour
{
    public int darknessDisplay;
    public TextMeshProUGUI darknessGUI;
    public float waitTime = 1.0f;
    public float lanternWaitTime = 10f;
    public float darknessWaitTime = 3f;
    public script_character_movement script_character_Movement;
    public script_ui_movement uiMoveAccess;
    public bool lanternIsLit = false;
    public script_third_person_controller thirdpersonAccess;
    public bool hasDarkness = false;
    public bool isSafe = true;
    bool lanternTimeRunner = false;
    public GameObject particleEffect;
    public bool firstLantern;
     
    AudioSource audioSource;
    public AudioClip litClip;
    //public Transform particleSpawn;

    // Start is called before the first frame update
    void Start()
    {
        darknessDisplayMethod();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject uimove = GameObject.Find("UIController");
        script_character_Movement = player.GetComponent<script_character_movement>();
        uiMoveAccess = uimove.GetComponent<script_ui_movement>();
        particleEffect.SetActive(false);
         thirdpersonAccess = player.GetComponent<script_third_person_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        darknessDisplayMethod();
        if (script_character_Movement.weightOfDarkness >= 10)
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
                particleEffect.SetActive(false);
                Debug.Log("the lantern turned off");
                lanternWaitTime = 18;
            }
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
            hasDarkness = false;
            isSafe = true;
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && lanternIsLit == true)
        {
            script_character_Movement.hasLightRounds = true;
            hasDarkness = false;
            thirdpersonAccess.bowLit = true;
            //Debug.Log("has darkness " + hasDarkness);
            isSafe = true;
            //Debug.Log("can shoot light damage" + script_character_Movement.hasLightRounds);

            //neeeds to start counting down----
            if (script_character_Movement.weightOfDarkness > 0)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    //Debug.Log(waitTime);
                }

                if (waitTime <= 0)
                {
                    script_character_Movement.weightOfDarkness -= 1;
                    uiMoveAccess.changeDown = true;
                    waitTime = 1.0f;
                }
            }
        }
        else
            script_character_Movement.hasLightRounds = false;
    }
    void darknessDisplayMethod()
    {

        if (darknessGUI)
        {
            darknessDisplay = (int)script_character_Movement.weightOfDarkness;
        
            if (script_character_Movement.weightOfDarkness <= 0)
            {
                darknessGUI.text = "";
            }

            else
                darknessGUI.text = "SOMBRE x" + darknessDisplay.ToString();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //GameObject other = collision.gameObject;

        //this is if the lantern was previously off--------------
        if (script_character_Movement.hasLightRounds && lanternIsLit == false && collision.collider.CompareTag("Arrow"))
        {
            Debug.Log("this lanter was off and now it is turning on");
            particleEffect.SetActive(true);
            //audioSource.PlayOneShot(litClip, 1.0F);
            //Debug.Log("ran particle");
            script_character_Movement.holdingLight = false;
            // Debug.Log("boolHoldingLightChar in Hands" + script_character_Movement.holdingLight);
            lanternIsLit = true;
            lanternChecking();
           
            Destroy(collision.gameObject);
            
            
        }

        if (script_character_Movement.holdingLight && collision.collider.CompareTag("Arrow"))
        {
            //Instantiate(particleEffect, particleSpawn.position, Quaternion.identity);
            particleEffect.SetActive(true);
            Debug.Log("ran particle");
            script_character_Movement.holdingLight = false;
            lanternIsLit = true;
            lanternChecking();
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //INSERT SOUND CLIP FOR LOSING LIGHT HERE
            script_character_Movement.hasLightRounds = false;
            Debug.Log("has light rounds" + script_character_Movement.hasLightRounds);
            isSafe = false;
            thirdpersonAccess.bowLit = false;
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
        
        else if (darknessWaitTime <= 0)
        {
           if (firstLantern)
           {
               script_character_Movement.weightOfDarkness++;
               uiMoveAccess.changeUp = true;
           }
            
            darknessWaitTime = 4f;
            Debug.Log("added one to weight of darkness");
        }
    }
}