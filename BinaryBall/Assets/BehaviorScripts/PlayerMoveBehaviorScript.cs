using UnityEngine;
using System.Collections;

public class PlayerMoveBehaviorScript : MonoBehaviour 
{
    public static Vector3 location;
    public float speed = 100;
    private int count;
    public Vector3 origin;
    void Start()
    {
        count = 0;
        origin = new Vector3(-8.94f,6.26f, 38.48f);
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
            count = 0;
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
            rigidbody.drag = 100;
        }
        else
        {
            rigidbody.drag = 0;
        }
        
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Pickup"))
        {
            count++;
            other.gameObject.SetActive(false);
            if (count >= 16)
            {

            }
        }
    }
}
