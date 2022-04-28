using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class script_lantern_boss : MonoBehaviour
{
    //public int gazeDisplay;
    //public TextMeshProUGUI gazeGUI;
    //public float waitTime = 1.0f;
    //public float lanternWaitTime = 10f;
    //public float darknessWaitTime = 3f;
    public script_character_movement script_character_Movement;
    public script_third_person_controller thirdpersonAccess;
    public script_gaze_manager Manager;
    public bool lanternIsLit = false;
    // public bool hasGaze = false;
    public bool isSafe = true;
    //bool lanternTimeRunner = false;
    public GameObject particleEffect;
    public bool firstLantern;
    //public float gazeMax = 16f;
    //public float gazeCurrent;
    AudioSource audioSource;
    public AudioClip litClip;

    //public Transform particleSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject gazemanager = GameObject.Find("GAZEMANAGER");
        script_character_Movement = player.GetComponent<script_character_movement>();
        thirdpersonAccess = player.GetComponent<script_third_person_controller>();
        Manager = gazemanager.GetComponent<script_gaze_manager>();
        particleEffect.SetActive(false);
        //Manager.hasGaze = true;
        isSafe = false;
        Manager.gazeCurrent = Manager.gazeMax;
        script_character_Movement.hasLightRounds = false;
        
    }

    // Update is called once per frame
    void Update()
    {    
        if (Manager.gazeCurrent <= 0 && Manager.hasGaze)
        {
            Debug.Log("death, reset");
            SceneManager.LoadScene("GameOver");
        }

        if (isSafe == false)
        {
            //Debug.Log(isSafe);
        }

        else if (isSafe == true)
        {
            Manager.hasGaze = false;
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
            Manager.hasGaze = false;
            isSafe = true;
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && lanternIsLit == true)
        {
            script_character_Movement.hasLightRounds = true;
            thirdpersonAccess.bowLit = true;

            Manager.hasGaze = false;
            //Debug.Log("has darkness " + hasDarkness);
            isSafe = true;
        }
        else if (other.tag == "Player" && lanternIsLit == false)
            script_character_Movement.hasLightRounds = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        //GameObject other = collision.gameObject;

        //this is if the lantern was previously off--------------
        if (script_character_Movement.hasLightRounds && lanternIsLit == false && collision.collider.CompareTag("Arrow"))
        {
            Debug.Log("this lantern was off and now it is turning on");
            particleEffect.SetActive(true);
            audioSource.PlayOneShot(litClip, 1.0F);
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
            thirdpersonAccess.bowLit = false;
            Debug.Log("getting gaze");
            isSafe = false;
            Manager.hasGaze = true;
            Manager.gazeCurrent = Manager.gazeMax;
        }
    }

}