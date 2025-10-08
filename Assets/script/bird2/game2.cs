using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class game2 : MonoBehaviour
{
    public enum GAME_STAUE
    { 
       Ready,
       InGame,
       GameOver
    }
    private GAME_STAUE _staue;
    private GAME_STAUE staue
    {
        get { return _staue; }
        set { this._staue = value;
            this.UpdatePanel();
        }
    }
    public GameObject ReadyPanel;
    public GameObject InGamePanel;
    public GameObject GameOverPanel;

    public PlpelineManager2 PlpelineManager;
    public UnitManager unitManager;

    public Player2 player;
    int score = 0;
    public Text text;
    public Text report1;
    public Text report2;
    bool isHasValue = true;

    public Slider HpBar;

    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
            this.text.text = score.ToString();
        }
    }

    void Start()
    {
        this.staue = GAME_STAUE.Ready;

        this.player.onDeath += Player_onDeath;
        this.player.getScore = onPlayScore;
        if (PlayerPrefs.HasKey("best score"))
        {
            report2.text = PlayerPrefs.GetString("best score");
            isHasValue = false;
        }
        else
        {
            report2.text = "0";
        }
    }
    void onPlayScore(int score)
    {
        this.Score += score;
    }
    private void Player_onDeath()
    {
        report1.text = text.text;
        if (int.TryParse(report2.text, out int bestScore) &&
            int.TryParse(report1.text, out int currentScore))
        {
            if (currentScore > bestScore)
            {
                report2.text = report1.text;
            }
        }
        this.staue = GAME_STAUE.GameOver;
        this.PlpelineManager.stop();
        this.unitManager.stop();
        this.player.deathani();
        undateBest();
    }

    // Update is called once per frame
    void Update()
    {
        this.HpBar.value = Mathf.Lerp(this.HpBar.value, this.player.HP, 0.05f);
    }
    public void startGame()
    {
        this.staue = GAME_STAUE.InGame;
        this.player.BeginPlayable();
        PlpelineManager.startRun();
        unitManager.Begin();
    }
    public void UpdatePanel()
    {
        this.ReadyPanel.SetActive(this.staue == GAME_STAUE.Ready);
        this.InGamePanel.SetActive(this.staue == GAME_STAUE.InGame);
        this.GameOverPanel.SetActive(this.staue == GAME_STAUE.GameOver);

    }
    public void restart()
    {
        this.staue = GAME_STAUE.Ready;
        this.PlpelineManager.init();
        this.player.init();
        text.text = "0";
        score = 0;
        this.player.HP = 10f;
    }
    public void undateBest()
    {
        if (PlayerPrefs.HasKey("best score"))
        {
            if (int.TryParse(report2.text, out int bestScore) &&
             int.TryParse(report1.text, out int currentScore))
            {
                if (currentScore > bestScore)
                {
                    PlayerPrefs.SetString("best score", report1.text);
                    PlayerPrefs.Save();
                }
            }
        }
        else
        {
            PlayerPrefs.SetString("best score", report1.text);
            PlayerPrefs.Save();
        }
        if (isHasValue)
        {
            report2.text = report1.text;
            isHasValue = false;
        }
    }
}
