using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class script_weapon_swap : MonoBehaviour
{
    public TextMeshProUGUI weaponNameGUI;
    private StarterAssetsInputs starterAssetsInputs;
    public bool bow;
    public bool sword;
    // Start is called before the first frame update
    void Start()
    {
        weaponNameGUI.text = "Bow";
        bow = true;
        sword = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.bow)
        {
            //equip bow
            //aniamation swap
            //instantiate bow
            bow = true;
            sword = false;
            starterAssetsInputs.sword = false;
            Debug.Log("bow then sword" + bow + sword);
            weaponNameGUI.text = "Bow";
        }

        if (starterAssetsInputs.sword)
        {
            //equip sword
            //animation swap
            //instantiate sword
            sword = true;
            bow = false;
            starterAssetsInputs.bow = false;
            
            Debug.Log("bow then sword" + bow + sword);
            weaponNameGUI.text = "Sword";

        }
    }
}
