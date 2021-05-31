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
    
    public float hitDamage;
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
    			hitPoints -= hitDamage;
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
