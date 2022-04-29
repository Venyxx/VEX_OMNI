using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_play_lines : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float lengthOfClip;
    public bool playing;
    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && playing == false)
        {
            playing = true;
            audioSource.PlayOneShot(audioClip, 10f);
            Invoke("waitSpace", lengthOfClip);
        }

    }

    void waitSpace()
    {
        Destroy(gameObject);
    }
}
