using UnityEngine;
using System.Collections;

public class MouseLookScript : MonoBehaviour 
{
    public enum RotationAxes { MouseXandY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivityX = 15;
    public float sensitivityY = 15;
    public float minX = -360;
    public float maxX = 360;
    public float minY = -60;
    public float maxY = 60;
    float rotationY = 0;

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (axes == RotationAxes.MouseXandY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minY, maxY);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);


            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minY, maxY);
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);

            }
        }
	}
    void Start()
    {

    }
}
