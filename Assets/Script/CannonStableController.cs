using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStableController : MonoBehaviour
{
    public GameObject missile;
    private Rigidbody rb;
    public float throwForce = 4000;
    private int randnum;
   
    void Start()
    {
        rb = missile.GetComponent<Rigidbody>(); 
    }


    void Update(){
        MakeAndThrowMissile();  
    }

    void MakeAndThrowMissile()
    {
        randnum = Random.Range(0, 100);
        if (randnum ==5)
        {
           GameObject missileInstance = Instantiate(missile, transform.position, transform.rotation);
           missileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
           Destroy(missileInstance, 1f);  
        } 
    }
}
