using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerratedController : MonoBehaviour
{
    private float thrustX = 0f;
    private float thrustY = 0.04f;
    private float thrustZ = 0f;
    private bool reverse = false;
    private Vector3 startPosition;
    public GameObject player;
    
    void Start()
    {
        startPosition = player.transform.position;
    }

    void Update()
    {
        if (!reverse)
        {
            transform.Translate(thrustX,thrustY,thrustZ);  
        }
        else
        {
            transform.Translate(thrustX,-thrustY,thrustZ);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "WallTriger")
        {
            reverse = !reverse;  
        }
        else if (other.name == "Player")
        {
            player.transform.position = startPosition;
            GameManager.instance.ToLoss();
        }
    }
}
