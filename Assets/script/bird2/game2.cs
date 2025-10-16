using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class game2 : MonoSingleton<game2>
{
    public int currentLevelId = 1;
    
    public GAME_STAUE _staue;
    public GAME_STAUE staue
    {
        get { return _staue; }
        set { this._staue = value;
            UIManager.instance.UpdatePanel();
        }
    }

    public Player2 player;
    bool isHasValue = true;

    void Start()
    {
        this.staue = GAME_STAUE.Ready;
        this.player.onDeath += Player_onDeath;        
    }
    
    private void Player_onDeath(unit sender)
    {   
        if(player.bird_life <= 0)
        {
            this.staue = GAME_STAUE.GameOver;
            PlpelineManager2.instance.stop();
            UnitManager.instance.Clear();
            this.player.deathani();
        }
        else
        {
            this.player.deathani();
            player.Rebirth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        this.staue = GAME_STAUE.InGame;
        this.player.BeginPlayable();
        PlpelineManager2.instance.startRun();
        UnitManager.instance.init();

        LoadLevel();
    }

    private void LoadLevel()
    {
        LevelManager.instance.LoadLevel(this.currentLevelId);
        //UIManager.instance.setUIName();
        LevelManager.instance.level.OnLevelEnd = OnLevelEnd;
    }

    private void OnLevelEnd(Level.LEVEL_RESULT result)
    {
        if(result == Level.LEVEL_RESULT.SUCCESS)
        {
            this.currentLevelId++;
            this.LoadLevel();
        }
        else
        {
            this.staue = GAME_STAUE.GameOver;
        }
    }

    
    public void restart()
    {
        this.staue = GAME_STAUE.Ready;
        PlpelineManager2.instance.init();
        this.player.init();
        UIManager.instance.Player_life.text = "0";
        this.player.HP = 100f;
    }
    
}
