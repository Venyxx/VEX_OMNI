using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cube_solstice : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Win")
        //Object name is the name of the GameObject you want to check for collisions with.
        {
            SceneManager.LoadScene("scene_hub");
        }
    }
}
