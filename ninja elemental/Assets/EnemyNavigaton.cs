using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigaton : MonoBehaviour
{
   	public NavMeshAgent myNavAgent;
   	public Transform player;
   	

    // Update is called once per frame
    void Update()
    {
        myNavAgent.SetDestination(player.position);
    }
}
