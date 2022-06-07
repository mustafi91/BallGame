using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCotroller : MonoBehaviour
{
    public Transform player;
    public GameObject missile;
    private Rigidbody rb;
    private float range = 25f;
    private float thrustX = 0f;
    private float thrustY = 0f;
    private float thrustZ = 0.1f;
    private int randnum;
    GameObject[] missiles;
   
    void Start()
    {
        rb = missile.GetComponent<Rigidbody>(); 
    }


    void Update(){
        CannonlockAt();
        MakeAndThrowMissile();  
    }

    void CannonlockAt()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            transform.LookAt(player.transform);
        } 
    }

    void MakeAndThrowMissile()
    {
        missiles = GameObject.FindGameObjectsWithTag("Missile");

        foreach (GameObject missile in missiles)
        {
            missile.transform.Translate(thrustX,thrustY,thrustZ);
            Destroy(missile, 25f);  
        }

        randnum = Random.Range(0, 100);
        if (randnum == 5)
        {
           GameObject missileInstance = Instantiate(missile, transform.position, transform.rotation); 
        } 
    }

}
