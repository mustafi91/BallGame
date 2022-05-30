using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallExplosionController : MonoBehaviour
{
    GameObject[] smallWalls;
     
    void Start()
    {
        if (smallWalls == null)
        {
            smallWalls = GameObject.FindGameObjectsWithTag("SmallWall");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MissilePlayer"))
        {
            foreach (GameObject smallWall in smallWalls)
            {
                smallWall.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
