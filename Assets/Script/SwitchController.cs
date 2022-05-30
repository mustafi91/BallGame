using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject door;
    public GameObject basePosition;
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = basePosition.transform.position;
            GetComponent<MeshRenderer>().material.color = Color.green;
            Destroy(door,3f);   
        }
       
    }
}
