using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class script_melee : MonoBehaviour
{
    // Start is called before the first frame update
    public script_weapon_swap weaponSwapAccess;
    public TextMeshProUGUI swingGUI;
    void Start()
    {
        swingGUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponSwapAccess.sword == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Swing();
                Invoke("UnSwing", 2f);
            }
        }
    }

    void Swing()
    {
        //animation
        //collider
        swingGUI.text = "SWING";
    }

    void UnSwing()
    {
        swingGUI.text = "";
    }


}
