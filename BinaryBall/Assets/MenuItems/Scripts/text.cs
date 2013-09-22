using UnityEngine;
using System.Collections;

public class text : MonoBehaviour 
{
    public int id;

    void OnMouseOver()
    {
        GameObject cam = GameObject.Find("/Main Camera");
        Main menu = cam.gameObject.GetComponent<Main>();
        menu.number = id;
    }

    void OnMouseExit()
    {
        GameObject cam = GameObject.Find("/Main Camera");
        Main menu = cam.gameObject.GetComponent<Main>();
        menu.number = 0;
    }
}
