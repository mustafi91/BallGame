using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GegnerController : MonoBehaviour
{
    public float cntdnw = 1f;
    public float throwForce = 100;
    public GameObject ball;


    // Update is called once per frame
    void Update()
    {
        // if(cntdnw>0)     
        // {         
        //     cntdnw -= Time.deltaTime;     
        // } 
        // if(cntdnw < 0)     
        // {         
        //     GameObject ballInstance = Instantiate(ball, transform.position, transform.rotation);
        //     ballInstance.GetComponent<Rigidbody>().AddForce(transform.forward  * throwForce);
        //     Destroy(ballInstance, 3f);  
        //     cntdnw = 1f;
        // } 

    }   
}
