using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalk : MonoBehaviour
{
    
    private float thrustX = 0f;
    private float thrustY = 0f;
    private float thrustZ = 0.02f;
    private bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!reverse)
        {
            transform.Translate(thrustX,thrustY,thrustZ);  
        }
        else
        {
            transform.Translate(thrustX,thrustY,-thrustZ);
        }
    }



    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("RightWall") || collision.gameObject.CompareTag("LeftWall"))
        {
            reverse = !reverse;
        }
    }
}