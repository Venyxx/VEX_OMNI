using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyScript2 : MonoBehaviour
 {
     public GameObject objectToDeactivate;
     public GameObject objectToDeactivate2;
     public GameObject objectToDeactivate3;
 
     private void Start()
     {
         StartCoroutine(ActivationRoutine());
     }
 
     private IEnumerator ActivationRoutine()
     {  
         //Turn the Game Oject back off after x sec.
         yield return new WaitForSeconds(58);
 
         //Game object will turn off
         objectToDeactivate.SetActive(false);
         objectToDeactivate2.SetActive(false);
         objectToDeactivate3.SetActive(false);
         
         
     }
 }