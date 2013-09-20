using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
    public int number = 0;

    private GameObject playgame, options, quit;

    private void Start()
    {
        playgame = GameObject.Find("/Text/Play");
        options = GameObject.Find("/Text/About");
        quit = GameObject.Find("/Text/Quit");
    }

    private void Update()
    {
        switch(number)
        {
            case 0:
                playgame.renderer.material.color = Color.white;
                options.renderer.material.color = Color.white;
                quit.renderer.material.color = Color.white;
                break;
            case 1:
                playgame.renderer.material.color = Color.red;
                options.renderer.material.color = Color.white;
                quit.renderer.material.color = Color.white;
                break;
            case 2:
                playgame.renderer.material.color = Color.white;
                options.renderer.material.color = Color.red;
                quit.renderer.material.color = Color.white;
                break;
            case 3:
                playgame.renderer.material.color = Color.white;
                options.renderer.material.color = Color.white;
                quit.renderer.material.color = Color.red;
                break;
        }

        if (Input.GetButtonDown("Fire1") && number != 0)
        {
            switch (number)
            {
                case 1:
                    Application.LoadLevel(1);
                    break;
                case 2:
                    // About Clicked - add link to website info page here.
                    Application.OpenURL("http://jamiesinn.ca/binaryball");
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }

    }
}
