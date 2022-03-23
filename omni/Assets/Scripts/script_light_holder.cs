using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class script_light_holder : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasLightInHolder = true;
    public script_character_movement playerScriptAccess;
    public script_lantern lanternAccess;
    public GameObject[] lanterns;
    //public TextMeshProUGUI lanternGUI;
    bool isThereLight;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScriptAccess = player.GetComponent<script_character_movement>();
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        //is the light depleted everywhere
         lanterns = GameObject.FindGameObjectsWithTag("Lantern");
         foreach (GameObject lan in lanterns)
         {
             lanternAccess = lan.GetComponent<script_lantern>();
             if (lanternAccess.lanternIsLit == false)
             {
                isThereLight = false;
             }
         }

         if (isThereLight == false)
         {
             Debug.Log("there is no light remaining, adding back");
             hasLightInHolder = true;
         }


         if(hasLightInHolder)
         {
             lanternGUI.text = "Active";
         }
         else 
         lanternGUI.text = "Inactive";
    } */

    void OnCollisionEnter (Collision collision)
    {
        //Debug.Log("the holder noticed");
        //GameObject other = collision.gameObject;
        //this is if the lantern was previously off--------------
        if (collision.collider.CompareTag("Arrow") && hasLightInHolder == true)
        {
            
            playerScriptAccess.holdingLight = true;
            Debug.Log("boolHoldingLight in Hands" + playerScriptAccess.holdingLight);
            hasLightInHolder = false;
            
            
        }
        
    }
}
