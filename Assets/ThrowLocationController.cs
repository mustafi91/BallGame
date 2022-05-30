using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLocationController : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            CannonPlayerController.throwLocation = true;  
        }
    }
}
