using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_weapon_swap : MonoBehaviour
{
    public TextMeshProUGUI weaponNameGUI;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //equip bow
            //aniamation swap
            //instantiate bow
            bow = true;
            sword = false;
            Debug.Log("bow then sword" + bow + sword);
            weaponNameGUI.text = "Bow";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //equip sword
            //animation swap
            //instantiate sword

            bow = false;
            sword = true;
            Debug.Log("bow then sword" + bow + sword);
            weaponNameGUI.text = "Sword";

        }
    }
}
