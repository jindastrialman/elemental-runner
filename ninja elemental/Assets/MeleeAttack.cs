using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
    	
    	if(other.gameObject.GetComponent<AttackCollider>())
    		other.gameObject.GetComponent<AttackCollider>().dealDamage(20f);
    		
    }
}
