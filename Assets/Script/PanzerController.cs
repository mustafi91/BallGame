using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PanzerController : MonoBehaviour
{
    private Vector3 startPosition;
    public Transform player;
    NavMeshAgent navMeshAgent;
    
    void Start()
    {
        startPosition = player.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = player.position;
    }
}
