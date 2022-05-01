using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_play_lines : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float lengthOfClip;
    public bool playing;
    public GameObject cam1;
    public GameObject brilltimer;
    public GameObject dolly2;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && playing == false)
        {
            var currentScene = SceneManager.GetActiveScene();
            var currentSceneName = currentScene.name;
            if (currentSceneName == "scene_solstice")
            {
                cam1.SetActive(true);
                dolly2.SetActive(true);
                brilltimer.SetActive(false);
            }

            playing = true;
            audioSource.PlayOneShot(audioClip, 10f);
            Invoke("waitSpace", lengthOfClip);
        }

    }

    void waitSpace()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentSceneName = currentScene.name;
        if (currentSceneName == "scene_solstice")
        {
            cam1.SetActive(false);
            dolly2.SetActive(false);
            brilltimer.SetActive(true);
        }

        Destroy(gameObject);
    }
}
