using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scipt_boss_control : MonoBehaviour
{
    // Start is called before the first frame update
    public bool favorsDark;
    public bool favorsLight;
    public float LDTimerMax = 10f;

    private float LDTimerCurrent;
    public Material skybox_light;
    public Material skybox_dark;
    public TextMeshProUGUI favorsGUI;
    

    void Start()
    {
        RenderSettings.skybox = skybox_light;
        LDTimerCurrent = LDTimerMax;
        favorsLight = true;
        favorsGUI.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        WaitSpace();
        if (LDTimerCurrent < 0 && favorsLight)
        {
            //boss regains favor of dark
            RenderSettings.skybox = skybox_dark;
            LDTimerCurrent = LDTimerMax;
            favorsLight = false;
            favorsDark = true;
            favorsGUI.text = "___ regains favor of the Dark";
            Debug.Log("Switching to dark");
            Invoke ("guiWaitSpace", 3f);
        }
        else if (LDTimerCurrent < 0 && favorsDark)
        {
            //regains favor of light;
            RenderSettings.skybox = skybox_light;
            LDTimerCurrent = LDTimerMax;
            favorsDark = false;
            favorsLight = true;
            favorsGUI.text = "____regains favor of the Light";
            Debug.Log("Switching to light");
            Invoke ("guiWaitSpace", 3f);
        }
    }

    void WaitSpace ()
    {
        if (LDTimerCurrent > 0)
        {
            LDTimerCurrent -= Time.deltaTime; 
        }
    }
     
    void guiWaitSpace ()
    {
        favorsGUI.text = "";
    }
   
}