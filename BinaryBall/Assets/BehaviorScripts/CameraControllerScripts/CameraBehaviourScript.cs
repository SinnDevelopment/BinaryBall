using UnityEngine;
using System.Collections;

public class CameraBehaviourScript : MonoBehaviour 
{
    public GameObject Player;
    private Vector3 offset;
    public static GameObject targetplayer;
    public Quaternion offsetRotation = new Quaternion(0, 10, 0, 0);
	
	void Start ()
    {
        offset = transform.position;
        targetplayer = Player;
	}
	
	
   
    
   
      

    
    void Update()
    {
        if (Input.GetKey("q"))
        {
            offset = Quaternion.AngleAxis(1, Vector3.up) * offset;
        } 
        if (Input.GetKey("e"))
        {
            offset = Quaternion.AngleAxis(-1, Vector3.up) * offset;
            
        }
        
    }
	void LateUpdate () 
    {
        transform.position = Player.transform.position + offset;
        transform.LookAt(Player.transform);
       
        
        
	}
}
