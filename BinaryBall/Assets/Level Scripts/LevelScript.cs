using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    
    public int LevelCode;
    public string LevelName;
    
    public static int GetCurrentLevelCode()
    {
        LevelScript lvl = new LevelScript();
        if (lvl.LevelCode != null)
        {
            return lvl.LevelCode;
        }
        else
            return 0;
    }
    public static string GetCurrentLevelName()
    {
        LevelScript lvl = new LevelScript();
        if (lvl.LevelName != null)
            return lvl.LevelName;
        else
            return "MainMenu";
    }
	
}
