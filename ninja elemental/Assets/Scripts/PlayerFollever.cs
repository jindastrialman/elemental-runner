using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollever : MonoBehaviour
{
    

	public Transform player;
	public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x,offset.y, player.position.z + offset.z );
    }
    
}
