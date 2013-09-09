using UnityEngine;
using System.Collections;

public class PlayerMoveBehaviorScript : MonoBehaviour 
{
    public float speed = 100;
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        
       
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float jumpMove = Input.GetAxis("Jump");
        Vector3 move = new Vector3(horizontalMove,jumpMove, verticalMove);
        

        rigidbody.AddForce(move *speed * Time.deltaTime);
   
	}
}
