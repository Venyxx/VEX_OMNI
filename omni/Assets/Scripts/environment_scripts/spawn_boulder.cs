using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_boulder : MonoBehaviour
{
    public GameObject boulder_object;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            boulder_object.SetActive(true);
        }
    }
}
