using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigaton : MonoBehaviour
{
   	public NavMeshAgent enemyNavigationAgent;
   	public Transform player;
   	
   	private enum AIState
	{
		Idle,
   		Follow,
   		Attack,
   		Stunned
	};
   	
   	private AIState currentAIState;
   	
	private void Start()
	{
		currentAIState = AIState.Idle;
		StartCoroutine(EnemyStateMachine());
	}
    private void Update()
    {
    	if(Vector3.Distance(player.position, transform.position) >= 15f)
    	{
    		currentAIState = AIState.Idle;
    	}
    	else
    	{
    		currentAIState = AIState.Follow;
    		if(Vector3.Distance(player.position, transform.position) <= 9f)
    			currentAIState = AIState.Attack;
    	}
    }
    private IEnumerator EnemyStateMachine()
    {
    	while(true)
    	{
    		switch (currentAIState)
    		{
    			case AIState.Idle:
    				enemyNavigationAgent.enabled = false;
    				yield return new WaitForSeconds(0.5f);
    				continue;
    			case AIState.Follow:
    				enemyNavigationAgent.enabled = true;
    				enemyNavigationAgent.SetDestination(player.position);
    				yield return new WaitForSeconds(0.5f);
    				continue;
    			case AIState.Attack:
    				Debug.Log("V ATAKU");
    				yield return new WaitForSeconds(0.5f);
    				continue;
    			case AIState.Stunned:
    				yield return new WaitForSeconds(0.5f);
    				// нужна логика для состояния оглушения и возможность её появления хддд
    				continue;
    				
    		}
    	}
    }
}
