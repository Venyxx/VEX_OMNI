using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class script_light_holder : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasLightInHolder = true;
    public script_character_movement playerScriptAccess;
    //public script_lantern script_Lantern;
    public script_lantern lanternAccess;
    public GameObject[] lanterns;
    //public TextMeshProUGUI lightHolderGUI;
    bool isThereLight;
    public float waitToCheckLightMax = 5;
    public float waitToCheckLight = 0;
    int numberChecking;
    public GameObject particleSys;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject lanterns = GameObject.Find("first_lantern_DONOTRENAME");
        playerScriptAccess = player.GetComponent<script_character_movement>();
        lanternAccess = lanterns.GetComponent<script_lantern>();
        hasLightInHolder = true;
        Debug.Log(hasLightInHolder);
        //lightHolderGUI.text = "Active";
        particleSys.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        waitSpace();
        
        if (playerScriptAccess.holdingLight == true)
        {
            hasLightInHolder = false;
        }
    }
    void waitSpace()
    {
        if (waitToCheckLight <= 0)
        {
            holderChecking();
            waitToCheckLight = waitToCheckLightMax;
        }
        
        else if (waitToCheckLight > 0)
        {
            waitToCheckLight -= Time.deltaTime;
            
            //Debug.Log ("waiting " + waitToCheckLight);
        }
    }

    void holderChecking()
    {
        //is the light depleted everywhere
        //Debug.Log("checking for light");
        lanterns = GameObject.FindGameObjectsWithTag("Lantern");
        foreach (GameObject lan in lanterns)
        {
            lanternAccess = lan.GetComponent<script_lantern>();
           
            if (lanternAccess.lanternIsLit == true)
            {
                numberChecking ++;
            }
            
            if (numberChecking > 0 || playerScriptAccess.holdingLight == true)
            {
                //somethings is on somewhere
                isThereLight = true;
            } 
            
            else if (numberChecking <= 0 && playerScriptAccess.holdingLight == false)
            { 
                //no light anywhere
                isThereLight = false;
            }
        }
        numberChecking = 0;
        
        if (isThereLight == false)
        {
            particleSys.SetActive(true);
            hasLightInHolder = true;
            Debug.Log("there is no light remaining, adding back " + hasLightInHolder);
        }
        
        else if (isThereLight == true)
        {
            Debug.Log("there is light");
            hasLightInHolder = false;
        }
        
        if (hasLightInHolder == true)
        {
            //lightHolderGUI.text = "Active";
        }
        
        else if (hasLightInHolder == false){}
            //lightHolderGUI.text = "Inactive";
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("the holder noticed");
        //GameObject other = collision.gameObject;
        //this is if the lantern was previously off--------------
        if (collider.tag == "Player" && hasLightInHolder == true)
        {
            particleSys.SetActive(false);
            playerScriptAccess.holdingLight = true;
            Debug.Log("boolHoldingLight in Hands " + playerScriptAccess.holdingLight);
            hasLightInHolder = false;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScriptAccess.hasLightRounds = false;
            Debug.Log("has light rounds" + playerScriptAccess.hasLightRounds);
            lanternAccess.isSafe = false;
            lanternAccess.hasDarkness = true;
            playerScriptAccess.firstPickLight = true;
        }
    }
}