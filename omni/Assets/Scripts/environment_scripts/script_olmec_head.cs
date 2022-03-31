using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_olmec_head : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform meteorSpawn;
    public GameObject meteor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        //this will change eventually, but for now it will just be on player collision
        if (collision.collider.tag == "Player")
        {
            Debug.Log("noticed player");
            Instantiate(meteor, meteorSpawn.position, Quaternion.identity);

        }
    }
}
