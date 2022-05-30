using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissilePlayerController : MonoBehaviour
{
    public float xAngle = 0;
    public float yAngle = 2;
    public float zAngle = 0;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            CannonPlayerController.numberOfMissiles = 30;   
        }
    }

    
}
