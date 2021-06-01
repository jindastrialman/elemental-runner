using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public GameObject selfObj;
    
    bool damageState;
    
    public Material idleMaterial;
    public Material painMaterial;
    public Renderer selfRenderer;
    
    public float hitPoints;
    public float damageCooldown;
    
    void Start()
    {
    	damageState = false;
    	StartCoroutine(damageCoroutine());
    }
    
	public void dealDamage(float damage = 0)
    {
    	
    	if(!damageState)
    	{
    		if(hitPoints > damage)
    		{
    			hitPoints -= damage;
    			damageState = true;
   			}
   			else
   			{
   				Destroy(selfObj);
    		}
    	}
    	
    }
    
    IEnumerator damageCoroutine()
    {
    	while(true)
    	{
    		if(damageState)
    		{
    			selfRenderer.material = painMaterial;
    			yield return new WaitForSeconds(damageCooldown);
    			damageState = false;
    			selfRenderer.material = idleMaterial;
    		}
    		else
    		{
    			yield return null;
    		}
    	}   
    }
}
