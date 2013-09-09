using UnityEngine;
using System.Collections;

public class PlayerMoveBehaviorScript : MonoBehaviour 
{
    public float speed;
    public float jumpspeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        
       
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
      //  float jumpMove = Input.GetAxis("Jump");
       // Vector3 jump = new Vector3(0, jumpMove, 0);
        Vector3 move = new Vector3(horizontalMove, 0, verticalMove);
        //jump = Vector3.up * (jumpspeed * Time.smoothDeltaTime);

        rigidbody.AddForce(move * speed * Time.deltaTime);
    //    rigidbody.AddForce(jump * jumpspeed * Time.deltaTime);
	}
}
