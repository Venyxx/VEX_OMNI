using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class script_lantern : MonoBehaviour
{
    public float characterDarkness = 5;
    public int darknessDisplay;
    public TextMeshProUGUI darknessGUI;
    public float waitTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        darknessDisplayMethod();
    }

    // Update is called once per frame
    void Update()
    {
        darknessDisplayMethod();
        if (characterDarkness >= 10)
        {
            Debug.Log("death, reset");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (characterDarkness > 0)
            {
                if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                    Debug.Log(waitTime);
                }
                
                if (waitTime <= 0)
                {
                    characterDarkness -= 1;
                    waitTime = 1.5f;
                }


            }
        }
    }
    void darknessDisplayMethod()
    {

        darknessDisplay = (int)characterDarkness;
        if (characterDarkness <= 0)
        {
            darknessGUI.text = "";
        }else
        darknessGUI.text = "SOMBRE x" + darknessDisplay.ToString();
    }
}
