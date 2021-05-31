using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhonePlayerFollever : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _tiltAngle;
    public float _movementSpeed;
    public GameObject attackSphere;
    
    private Vector3 CachedDirection;
    private bool isAttacking = false;
    
    public Joystick _joystick;
    
    void Start()
    {
    
    	StartCoroutine(Attack());
    	CachedDirection = new Vector3(0,0,0);
    
    }
    
    void Update()
    {
		// Smoothly tilts a transform towards a target rotation.
        Vector2 direction2D = _joystick.Direction;
        Debug.Log(direction2D.ToString());
        if( Mathf.Abs(direction2D.x) > 0.05f || Mathf.Abs(direction2D.y) > 0.05f)
        	CachedDirection = new Vector3(direction2D.x, 0 , direction2D.y);
                // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.LookRotation(CachedDirection, Vector3.up);
        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 10.0f);
        
        if(	Quaternion.Angle(transform.rotation, target) <= 25f && 
        	(Mathf.Abs(direction2D.x) > 0.1f || Mathf.Abs(direction2D.y) > 0.1f))
        {
        	_rigidbody.AddRelativeForce(-1f * _movementSpeed * Time.deltaTime,0,0, ForceMode.VelocityChange);
        }
        
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
    			attackSphere.SetActive(true);
    			yield return new WaitForSeconds(0.5f);
    			attackSphere.SetActive(false);
    			yield return new WaitForSeconds(0.5f);
    			isAttacking = false;
    		}
    		else
    		{
    			yield return null;
    		}
    	}
    }
}
