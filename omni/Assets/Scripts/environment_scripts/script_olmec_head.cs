using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_olmec_head : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform meteorSpawn;
    public GameObject meteor;
     
    AudioSource audioSource;
    public AudioClip olmecNoise;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider collision)
    {
        GameObject player = collision.GetComponent<GameObject>();
        Debug.Log("noticed col");
        //this will change eventually, but for now it will just be on player collision
        if (collision.tag == "Player")
        {
            
            Debug.Log("noticed player");
            Instantiate(meteor, meteorSpawn.transform);
            audioSource.PlayOneShot(olmecNoise, 0.5F);

        }
    }
}
