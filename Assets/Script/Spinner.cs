using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
   public float xAngle = 0;
   public float yAngle = 0.2f;
   public float zAngle = 0;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);      
    }
}
