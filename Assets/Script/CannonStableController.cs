using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStableController : MonoBehaviour
{
    public GameObject missile;
    private Rigidbody rb;
    private int timer = 1;
    public float throwForce = 4000;
   
    void Start()
    {
        rb = missile.GetComponent<Rigidbody>(); 
    }


    void Update(){
        MakeAndThrowMissile();  
    }

    void MakeAndThrowMissile()
    {
        ++timer;
        if (timer % 183 == 0)
        {
           GameObject missileInstance = Instantiate(missile, transform.position, transform.rotation);
           missileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
           Destroy(missileInstance, 1f);  
        } 
    }
}
