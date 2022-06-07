using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanzerLockAt : MonoBehaviour
{
    public Transform player;
    public Transform throwPosition;
    public GameObject missile;
    private int randnum;
    public float throwForce = 4000;


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
        GameObject missileInstance = Instantiate(missile, throwPosition.transform.position, transform.rotation);
        missileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        Destroy(missileInstance, 1f);  
    }

}
