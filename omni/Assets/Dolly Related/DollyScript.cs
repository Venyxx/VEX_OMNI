using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyScript : MonoBehaviour
 {
     public GameObject objectToDeactivate;
     public GameObject objectToActivate;
 
     private void Start()
     {
         StartCoroutine(ActivationRoutine());
     }
 
     private IEnumerator ActivationRoutine()
     {  
         //Turn the Game Oject back off after x sec.
         yield return new WaitForSeconds(22);
 
         //Game object will turn off
         objectToDeactivate.SetActive(false);
         objectToActivate.SetActive(true);
     }
 }