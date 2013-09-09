using UnityEngine;
using System.Collections;

public class PlayerMoveBehaviorScript : MonoBehaviour 
{
    
    public float speed = 100;
    public Vector3 origin;
    void Start()
    {
        origin = new Vector3(0, 0, 0);
        
    }
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
                      
                transform.position = origin;
            
        }
    }
	void FixedUpdate () 
    {
        
       
        
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float jumpMove = Input.GetAxis("Jump");
        Vector3 move = new Vector3(horizontalMove,jumpMove, verticalMove);
        

        rigidbody.AddForce(move *speed * Time.deltaTime);
   
	}
}
