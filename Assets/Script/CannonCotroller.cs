using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCotroller : MonoBehaviour
{
    public Transform player;
    public GameObject missile;
    private Rigidbody rb;
    private int timer = 1;
    private float range = 25f;
    private float thrustX = 0f;
    private float thrustY = 0f;
    private float thrustZ = 0.1f;
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
        ++timer;

        missiles = GameObject.FindGameObjectsWithTag("Missile");

        foreach (GameObject missile in missiles)
        {
            missile.transform.Translate(thrustX,thrustY,thrustZ);
            Destroy(missile, 25f);  
        }

        if (timer % 183 == 0)
        {
           GameObject missileInstance = Instantiate(missile, transform.position, transform.rotation); 
        } 
    }

}
