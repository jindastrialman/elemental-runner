using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhonePlayerFollever : MonoBehaviour
{
    public CharacterController _characterController;
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
        if( Mathf.Abs(_joystick.Horizontal) > 0.05f || Mathf.Abs(_joystick.Vertical) > 0.05f)
        	CachedDirection = new Vector3(_joystick.Horizontal, 0 , _joystick.Vertical);
                // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.LookRotation(CachedDirection, Vector3.up);
        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 10.0f);
        
        if(	Quaternion.Angle(transform.rotation, target) <= 70f && 
        	(Mathf.Abs(_joystick.Horizontal) > 0.1f || Mathf.Abs(_joystick.Vertical) > 0.1f))
        {
        	_characterController.Move(new Vector3(-1f * _joystick.Vertical * _movementSpeed * Time.deltaTime, 0,
        	 									  		_joystick.Horizontal * _movementSpeed * Time.deltaTime));
        	if(!_characterController.isGrounded)
        	{
        		_characterController.Move(new Vector3(0, -1f, 0));
        	}
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
