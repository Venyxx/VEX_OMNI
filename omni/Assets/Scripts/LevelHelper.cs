using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHelper : MonoBehaviour
{

    public AudioClip helpTrack;
    AudioSource audioSource;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
         audioSource.PlayOneShot(helpTrack, 20F);
         GetComponent<Collider>().enabled = false;
    }
}
