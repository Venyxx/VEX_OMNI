using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_arrow_projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody arrowRigidBody;
    public LayerMask whatIsEnemies;

    private void Awake ()
    {
        arrowRigidBody = GetComponent<Rigidbody>();

    } 

    private void Start ()
    {
       float speed = 40f;
        arrowRigidBody.velocity = transform.forward * speed;

    }

    private void OnCollisonEnter (Collision collision)
    {
        if (collision.collider.CompareTag("Lantern"))
        {
            Destroy(gameObject);
        }
        
    }
}
