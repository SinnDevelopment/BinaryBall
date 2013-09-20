using UnityEngine;
using System.Collections;

public class text : MonoBehaviour 
{
    public int id;

    private void OnMouseOver()
    {
        GameObject cam = GameObject.Find("/Main Camera");
        Main menu = cam.gameObject.GetComponent<Main>();
        menu.number = id;
    }

    private void OnMouseExit()
    {
        GameObject cam = GameObject.Find("/Main Camera");
        Main menu = cam.gameObject.GetComponent<Main>();
        menu.number = 0;
    }
}
