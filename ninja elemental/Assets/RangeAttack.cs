using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{

	public float attackDamage;
	//int layerMask;
	bool isAttacking;
	
	public LineRenderer _lineRenderer;
    	
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
       					
       				Vector3[] array = new Vector3[2];
       				array[0] = transform.position;
       				array[1] = hit.point;
       					
       				_lineRenderer.enabled = true;
       				_lineRenderer.SetPositions(array);
       			}
    			yield return new WaitForSeconds(0.3f);
    			_lineRenderer.enabled = false;
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
