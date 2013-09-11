using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour 
{
    public GameObject Player;
    private Vector3 offset;
    
	// Use this for initialization
	void Start ()
    {
        offset = transform.position;
	}
	
	// Update is called once per frame
  
    void Update()
    {
        if (Input.GetKey("q"))
        {

        } 
        if (Input.GetKey("e"))
        {

        }
        //transform.LookAt(Player.transform);
    }
	void LateUpdate () 
    {
        transform.position = Player.transform.position + offset;
        transform.LookAt(Player.transform);
       // transform.rotation.Set(0, Player.transform.rotation.eulerAngles.y, 0, 0);
        
        
	}
}
