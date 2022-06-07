using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform enemy;
    
    void Update()
    {
       GetComponent<NavMeshAgent>().destination = enemy.position;
    }
}
