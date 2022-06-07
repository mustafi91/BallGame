using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherController : MonoBehaviour
{
    public Transform player;
    public Transform throwPosition1;
    public Transform throwPosition2;
    public Transform throwPosition3;
    public Transform throwPosition4;
    public Transform throwPosition5;
    public GameObject missile;
    private int randnum;
    public float throwForce = 8000;
    
    void Update(){
        CannonlockAt();
        randnum = Random.Range(0, 200);
        if (randnum ==5)
        {
           MissileInstated();    
        }
    }

    void CannonlockAt()
    {
        transform.LookAt(player.transform);
    }

    void MissileInstated()
    {
        GameObject missileInstance1 = Instantiate(missile, throwPosition1.position, transform.rotation);
        GameObject missileInstance2 = Instantiate(missile, throwPosition2.position, transform.rotation);
        GameObject missileInstance3 = Instantiate(missile, throwPosition3.position, transform.rotation);
        GameObject missileInstance4 = Instantiate(missile, throwPosition4.position, transform.rotation);
        GameObject missileInstance5 = Instantiate(missile, throwPosition5.position, transform.rotation);
        missileInstance1.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        missileInstance2.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        missileInstance3.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        missileInstance4.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        missileInstance5.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        Destroy(missileInstance1, 1f);  
        Destroy(missileInstance2, 1f); 
        Destroy(missileInstance3, 1f); 
        Destroy(missileInstance4, 1f); 
        Destroy(missileInstance5, 1f); 
    }
}
