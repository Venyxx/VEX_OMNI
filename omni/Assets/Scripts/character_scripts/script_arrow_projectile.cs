using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_arrow_projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody arrowRigidBody;
    public LayerMask whatIsEnemies;
    private float despawntime = 10f;
    private float despawn;

    private void Awake ()
    {
        arrowRigidBody = GetComponent<Rigidbody>();

    } 

    private void Start ()
    {
       float speed = 70f;
        arrowRigidBody.velocity = transform.forward * speed;
        despawn = despawntime;
        Debug.Log("spawn");
    }

    private void Update()
    {
        if (despawn > 0)
        {
            despawn -= Time.deltaTime;
            //Debug.Log(despawn);
        }
        else if (despawn < 0 )
        {
            Destroy(arrowRigidBody);
           //Debug.Log("destroy");
        }
        
    }

    private void OnCollisonEnter (Collision collision)
    {
        
        
    }
}
