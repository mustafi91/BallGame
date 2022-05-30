using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CannonPlayerController : MonoBehaviour
{
   public static bool throwLocation = false; 
   public static int numberOfMissiles = 0;


   public GameObject missile;
   public float throwForce = 4000;

    void Update(){
        MakeAndThrowMissile();  
    }



    void MakeAndThrowMissile()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame && throwLocation && numberOfMissiles > 0)
        {
           GameObject missileInstance = Instantiate(missile, transform.position, transform.rotation);
           missileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
           Destroy(missileInstance, 1f);  
           --numberOfMissiles;
        } 
    }
}
