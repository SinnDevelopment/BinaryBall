using UnityEngine;
using System.Collections;

public class PlayerMoveBehaviorScript : MonoBehaviour 
{
    public static Vector3 location;
    public float speed = 100;
    public Vector3 origin;
    void Start()
    {
        origin = new Vector3(0, 0, 0);
        rigidbody.drag = 0.1f;
        location = rigidbody.position;
    }
	// Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 15)
        {
            rigidbody.drag = 20;
        }
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

        rigidbody.AddForce(move * speed * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) && Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
        {
            rigidbody.drag = 10;
        }
        else
        {
            rigidbody.drag = 0;
        }
        if(Input.GetKey("q"))
        {
           
            transform.Rotate(0,0.5f, 0);
            

        }
        
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Pickup"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
