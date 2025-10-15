using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtil :singleton<GameUtil>
{
    public bool InScreen(Vector3 position)
    {
        return Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(position));
        
    }   
}
