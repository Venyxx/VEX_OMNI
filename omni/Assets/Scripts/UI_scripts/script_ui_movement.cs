using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_ui_movement : MonoBehaviour
{
    public GameObject leftMost;
    public GameObject rightMost;
    //public Transform center;
    public Transform leftStart;
    public Transform rightStart;

    public float leftLocation;
    public float rightLocation;
    Transform leftPos;
    Transform rightPos;

    public script_character_movement characterAccess;
    GameObject player;
    Vector2 screenCenterPoint;
    Vector3 leftPosStart;
    public bool changeUp = false;
    public bool changeDown = false;
    Vector3 updating = new Vector3(81.5f,0,0);

    // Start is called before the first frame update
    void Start()
    {
         leftPos = leftMost.GetComponent<Transform>();
         rightPos = rightMost.GetComponent<Transform>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        characterAccess = player.GetComponent<script_character_movement>();
        //screenCenterPoint = new Vector3(Screen.width / 2f, Screen.height / 2f,0);
       //  leftPosStart = new Vector3(leftPos.transform.position.x, leftPos.transform.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 leftPosVector = new Vector3(0,0,0);
        
       // leftPosVector.x = leftPos.transform.position.x;
        //leftPosVector.y = leftPos.transform.position.y;
        
       // Debug.Log("screen center" + screenCenterPoint + "left pos" + leftPosVector);

        if(changeUp)
        {
            Increase();
        }

        if (changeDown)
        {
            Decrease();
        }
        

       

    }

    void Increase ()
    {
        leftPos.transform.position = Vector2.Lerp(leftPos.transform.position, leftPos.transform.position + updating,  20f );
        rightPos.transform.position = Vector2.Lerp(rightPos.transform.position, rightPos.transform.position - updating,  20f);
        changeUp = false;
    }

    void Decrease ()
    {
        leftPos.transform.position = Vector2.Lerp(leftPos.transform.position, leftPos.transform.position - updating,  20f);
        rightPos.transform.position = Vector2.Lerp(rightPos.transform.position, rightPos.transform.position + updating,  20f);
        changeDown = false;
    }
}
