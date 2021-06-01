using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

	public float attackDamage;
	//int layerMask;
	bool isAttacking;
    	
    Ray _ray;
   	RaycastHit hit;
       	
	
	void Start()
	{
		//layerMask = 1 << 7;
	
		StartCoroutine(Attack());
	}
	
    void FixedUpdate()
    {
       	_ray = new Ray(transform.position, transform.forward);
    }
    
    public void OnAttackButtonDown()
    {
    	if(!isAttacking)
    		isAttacking = true;
    }
    
    IEnumerator Attack()
    {
    	Debug.Log("a korutinka idet))");
    	while(true){
    		if(isAttacking)
    		{
    			if(Physics.Raycast(_ray, out hit))
       			{
       				if(hit.collider.gameObject.GetComponent<AttackCollider>())
       					hit.collider.gameObject.GetComponent<AttackCollider>().dealDamage(attackDamage);
       	
       			}
    			yield return new WaitForSeconds(0.3f);
    			Debug.Log("bang");
    			isAttacking = false;
    		}
    		else
    		{
    			yield return null;
    		}
    	}
    }
}
