using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public GameObject self;
    
    public Rigidbody _rigidbody;
    
    bool damageState;
    
    public float hitDamage;
    public float knockbackForce;
    public float hitPoints;
    public float damageCooldown;
    
    void Start()
    {
    	damageState = false;
    	StartCoroutine(damageCoroutine());
    }
    
	void OnTriggerEnter(Collider other)
    {
    	if(other.tag == "AbilityCast")
    	{
    		if(hitPoints > hitDamage)
    		{
    			damageState = true;
    		}
    		else
    		{
    			Destroy(self);
    		}
    	}
    	
    }
    
    IEnumerator damageCoroutine()
    {
    	while(true)
    	{
    		if(damageState)
    		{
    			hitPoints -= hitDamage;
    			yield return new WaitForSeconds(damageCooldown);
    			damageState = false;
    		}
    		else
    		{
    			yield return null;
    		}
    	}   
    }
}
