using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class meteor_move : MonoBehaviour
{
    public float speed;
    public GameObject impactPrefab;
    private Rigidbody rb;
    public List<GameObject> trails;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(speed != 0 && rb != null)
        {
            rb.position += transform.forward * (speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0; 

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point; 



        if(impactPrefab != null)
        {
            var impactVFX = Instantiate(impactPrefab, pos, rot) as GameObject;
            Destroy(impactVFX, 5);
        }
        if(trails.Count > 0)
        {
            for(int i = 0; i< trails.Count; i++)
            {
                trails[i].transform.parent = null;
                var ps = trails[i].GetComponent<ParticleSystem>();
                if(ps != null)
                {
                   
                    Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }

        if( collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("scene_vs_eclipse");
        }

        Destroy(gameObject);
    }
}
