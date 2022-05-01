using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_intro_stopper : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool ranIntro = false;
    void Start()
    {
        GameObject stopRunningTheIntroAgain;
        stopRunningTheIntroAgain = GameObject.Find("stopRunningTheIntroAgain");
        DontDestroyOnLoad(stopRunningTheIntroAgain);
    }

    // Update is called once per frame
    void Update()
    {
        if(ranIntro == false)
        {
            ranIntro = true;
        }
    }
}
