using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject player;
    private Vector3 labelPosition;
    
    void Start()
    {
         labelPosition = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + labelPosition; 
    }
}
