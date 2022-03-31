using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_custom_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public GameObject explosions;
    public LayerMask whatIsEnemies;

    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    public int explosionDamage;
    public float explosionRange;

    public int maxCollisions;
    public float maxLife;
    public bool explodeOnTouch = true;
    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update ()
    {
        if (collisions > maxCollisions)
        {
            Explode ();

        }
        maxLife -= Time.deltaTime;
        if (maxLife <=0)
        Explode ();
    }

    private void Explode ()
    {
        //make xplody
        if (explosions !=null)
        Instantiate(explosions, transform.position, Quaternion.identity);

        //enemmmieees?
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //what to dooo

        }
        Invoke ("Delay", 0.5f);

    }

    private void Delay ()
    {
        Destroy(gameObject);
    }
    private void Setup()
    {
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        GetComponent<SphereCollider>().material = physics_mat;

        rb.useGravity = useGravity;
    }

    void OnCollisionEnter (Collision collision)
    {
        collisions ++;

        if (collision.collider.CompareTag("Lantern") && explodeOnTouch)
        Explode();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
    
}
