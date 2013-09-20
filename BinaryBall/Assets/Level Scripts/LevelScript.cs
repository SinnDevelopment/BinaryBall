using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour
{
    /// <summary>
    /// Attach this to the camera of each scene. And increase the levelcode sequentially based upon what sequence you want them in
    /// </summary>
    public int LevelCode;
    public int GetCurrentLevelCode()
    {
        if (LevelCode != null)
        {
            return LevelCode;
        }
        else
            return 0;
    }
	
}
