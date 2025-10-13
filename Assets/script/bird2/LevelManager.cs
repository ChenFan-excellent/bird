using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> Levels;
    public int currentLevelId = 1;

    public Level level;

    public UnitManager unitManager;
    public Player2 currentPlayer;

    public void LoadLevel(int levelID)
    {
        this.level.unitManager = this.unitManager;
        this.level = Instantiate<Level>(Levels[levelID - 1]);
        this.level.currentPlayer = this.currentPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
