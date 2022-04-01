using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class script_melee : MonoBehaviour
{
    // Start is called before the first frame update
    
    private StarterAssetsInputs starterAssetsInputs;
    
    public TextMeshProUGUI swingGUI;
    void Start()
    {
        swingGUI.text = "";
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.shoot && starterAssetsInputs.sword)
        {
        	//input sll sword related animations here 
            
          
        }
    }

    void Swing()
    {
        //animation
        //collider
    }



}
