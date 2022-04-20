using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_ui_movement : MonoBehaviour
{
    public GameObject leftMost;
    public GameObject rightMost;
    public Transform center;
    public Transform leftStart;
    public Transform rightStart;

    public float leftLocation;
    public float rightLocation;

    public script_lantern lanternAccess;

    // Start is called before the first frame update
    void Start()
    {
        Transform leftPos = leftMost.GetComponent<Transform>();
        Transform rightPos = rightMost.GetComponent<Transform>();
        GameObject lanternOne = GameObject.Find("first_lantern_DONOTRENAME");
        lanternAccess = lanternOne.GetComponent<script_lantern>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
