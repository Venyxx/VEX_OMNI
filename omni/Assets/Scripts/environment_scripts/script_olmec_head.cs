using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class script_olmec_head : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform meteorSpawn;
    public GameObject meteor;

    AudioSource audioSource;
    public AudioClip olmecNoise;
    script_third_person_controller thirdAccess;
    private StarterAssetsInputs starterAssetsInputs;
    private script_character_movement script_character_Movement;
     private script_brilliance script_Brilliance;
     public GameObject door1OBJ;
      public GameObject door2OBJ;
       public GameObject door3OBJ;
        public GameObject door4OBJ;
    


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
         script_character_Movement = player.GetComponent<script_character_movement>();
        thirdAccess = player.GetComponent<script_third_person_controller>();
        starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
        GameObject brill = GameObject.FindGameObjectWithTag("BRILLHOLD");
         script_Brilliance = brill.GetComponent<script_brilliance>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (door1OBJ != null && gameObject.tag == "door1" && collider.tag == "Player")
        {
            door1OBJ.SetActive(false);
        }
        if (door2OBJ != null &&gameObject.tag == "door2" && collider.tag == "Player")
        {
            door2OBJ.SetActive(false);
        }
        if (door3OBJ != null &&gameObject.tag == "door3" && collider.tag == "Player")
        {
            door3OBJ.SetActive(false);
        }
        if (door4OBJ != null &&gameObject.tag == "door4" && collider.tag == "Player")
        {
            door4OBJ.SetActive(true);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        //Debug.Log("noticed player presence");
        thirdAccess.swordLit = true;
        script_Brilliance.hasSol = false;
        GameObject player = collision.GetComponent<GameObject>();
        script_character_Movement.hasLightRounds = true;
        //Debug.Log("noticed col");
        //this will change eventually, but for now it will just be on player collision

        //Debug.Log(starterAssetsInputs.sword + "Sword" + starterAssetsInputs.shoot + "swing");
        if (collision.tag == "Player" && starterAssetsInputs.sword && starterAssetsInputs.shoot)
        {

            Debug.Log("noticed player holding sword and ritual=======================================");
            Instantiate(meteor, meteorSpawn.transform);
            Debug.Log (meteor);
            //audioSource.PlayOneShot(olmecNoise, 0.5F);

        }
    }

    void OnTriggerExit (Collider collider)
    {
       if (collider.tag == "Player")
       {
           thirdAccess.swordLit = false;
           script_character_Movement.hasLightRounds = false;
           script_Brilliance.hasSol = true;

       }
    }
}
