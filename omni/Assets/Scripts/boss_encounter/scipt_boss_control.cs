using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scipt_boss_control : MonoBehaviour
{
    // Start is called before the first frame update
    public bool favorsDark;
    public bool favorsLight;
    private float LDTimerMax = 10f;

    private float LDTimerCurrent;
    public Material skybox_light;
    public Material skybox_dark;

    void Start()
    {
        RenderSettings.skybox = skybox_light;
        LDTimerCurrent = LDTimerMax;
        favorsLight = true;
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

            Debug.Log("Switching to dark");
        }
        else if (LDTimerCurrent < 0 && favorsDark)
        {
            //regains favor of light;
            RenderSettings.skybox = skybox_light;
            LDTimerCurrent = LDTimerMax;
            Debug.Log("Switching to light");
        }
    }

    void WaitSpace ()
    {
        if (LDTimerCurrent > 0)
        {
            LDTimerCurrent -= Time.deltaTime; 
        }
    }
}
