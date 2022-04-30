using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaguarJak : MonoBehaviour
{
    public GameObject borealis;
    public GameObject finalCam;
    public GameObject finalTimeline;
    public GameObject thatBoy;
    public GameObject gazestop;

    void Start()
    {
        
    }

void OnTriggerEnter(Collider other)
    {
    
            borealis.SetActive(false);
            finalCam.SetActive(true);
            finalTimeline.SetActive(true);
            thatBoy.SetActive(true);
    gazestop.SetActive(false);
    
}
}
