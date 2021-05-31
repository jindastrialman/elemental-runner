using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _rotationSpeed;
    public float _movementSpeed;
    public GameObject attackSphere;
    
    void Start()
    {
    
    	StartCoroutine(Attack());
    
    }
    
    void FixedUpdate()
    {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		//Debug.Log(h.ToString() + " " + v.ToString());
		
		_rigidbody.AddRelativeForce( -1 * v * Time.deltaTime * _movementSpeed, 0, 0, ForceMode.VelocityChange);
		transform.Rotate(Vector3.up, _rotationSpeed * h);
    }
    
    
    IEnumerator Attack()
    {
    	Debug.Log("a korutinka idet))");
    	while(true){
    		if(Input.GetKey("space"))
    		{
    			attackSphere.SetActive(true);
    			yield return new WaitForSeconds(0.5f);
    			attackSphere.SetActive(false);
    			yield return new WaitForSeconds(0.5f);
    		}
    		else
    		{
    			yield return null;
    		}
    	}
    }
 }
