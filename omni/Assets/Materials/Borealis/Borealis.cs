using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borealis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh.bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 1,1) * 10.0f); 
    }

}
