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
  
        Vector3 move = new Vector3(horizontalMove, 0.0f, verticalMove);
        //jump = Vector3.up * (jumpspeed * Time.smoothDeltaTime);

        rigidbody.AddForce(move);
    //    rigidbody.AddForce(jump * jumpspeed * Time.deltaTime);
	}
}
