using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_light_holder : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasLightInHolder = true;
    public script_character_movement playerScriptAccess;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScriptAccess = player.GetComponent<script_character_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
