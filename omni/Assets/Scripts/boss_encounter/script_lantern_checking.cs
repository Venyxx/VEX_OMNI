using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script_lantern_checking : MonoBehaviour
{
    // Start is called before the first frame update
    script_lantern_boss L1Access;
    script_lantern_boss L2Access;
    script_lantern_boss L3Access;
    script_lantern_boss L4Access;
    public GameObject L1Shield;
    public GameObject L2Shield;
    public GameObject L3Shield;
    public GameObject L4Shield;
    public TextMeshProUGUI encounterDisplay;

    void Start()
    {
        GameObject lanternOne = GameObject.Find("first_lantern_DONOTRENAME");
        GameObject lanternTwo = GameObject.Find("lantern_object_boss_variant_SEC");
        GameObject lanternThree = GameObject.Find("lantern_object_boss_variant_THIR");
        GameObject lanternFour = GameObject.Find("lantern_object_boss_variant_FOUR");
        L1Access = lanternOne.GetComponent<script_lantern_boss>();
        L2Access = lanternTwo.GetComponent<script_lantern_boss>();
        L3Access = lanternThree.GetComponent<script_lantern_boss>();
        L4Access = lanternFour.GetComponent<script_lantern_boss>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (L1Access.lanternIsLit && L2Access.lanternIsLit && L3Access.lanternIsLit && L4Access.lanternIsLit)
        {
            //display method -- 
            encounterDisplay.text = "The space thrums with light energy";
        }

        if (L1Access.lanternIsLit)
        {
            L1Shield.SetActive(false);
        }
        if (L2Access.lanternIsLit)
        {
            L2Shield.SetActive(false);
        }
        if (L3Access.lanternIsLit)
        {
            L3Shield.SetActive(false);
        }
        if (L4Access.lanternIsLit)
        {
            L4Shield.SetActive(false);
        }

    }
}
