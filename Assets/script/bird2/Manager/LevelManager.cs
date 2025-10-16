using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public List<Level> Levels;
    public int currentLevelId = 1;

    public Level level;

    public void LoadLevel(int levelID)
    {
        this.level = Instantiate<Level>(Levels[levelID - 1]);
        Debug.LogFormat("LevelID - 1  =  {0}", levelID - 1);
    }
}
