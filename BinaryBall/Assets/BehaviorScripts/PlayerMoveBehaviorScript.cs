using UnityEngine;
using System.Collections;

public class PlayerMoveBehaviorScript : MonoBehaviour 
{
    public static Vector3 location;
    public float speed = 100;
    private int count;
    private Vector3 origin = new Vector3(-9.736831f, 5.166971f, 39.93442f);
    public GUIText countText;

    void Start()
    {
        SetCountText();
        count = 0;
        
        rigidbody.drag = 0.1f;
        location = rigidbody.position;
    }
	// Update is called once per frame
    void Update()
    {
       // Move();
        
        
    }
    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
    }

	void FixedUpdate () 
    {
        if (networkView.isMine)
        {
            InputMovement();
        }
       
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Pickup"))
        {
            count++;
            SetCountText();
            other.gameObject.SetActive(false);
            if (count.Equals(16))
            {
                countText.text = " GAME OVER REFRESH PAGE TO PLAY AGAIN.";
            }
        }
    }
    void SetCountText()
    {
        countText.text = "Cubes Collected: " + count.ToString();
    }
    void ResetPosition()
    {
        rigidbody.position = origin;
        rigidbody.rotation.Set(0, 0, 0, 0);
    }
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float jumpMove = Input.GetAxis("Jump");
        Vector3 move = new Vector3(horizontalMove, jumpMove, verticalMove);

        rigidbody.AddForce(move * speed * Time.deltaTime);
        
    }
}