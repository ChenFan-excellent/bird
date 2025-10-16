using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject ReadyPanel;
    public GameObject InGamePanel;
    public GameObject GameOverPanel;

    public Slider HpBar;

    public Text uiTextName;
    public Text uiShowName;

    public Text Player_life;

    public GameObject UILevelStart;
    public GameObject UILevelEnd;

    // Start is called before the first frame update
    void Start()
    {
        ReadyPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        this.HpBar.value = Mathf.Lerp(this.HpBar.value, game2.instance.player.HP, 0.05f);
        if (game2.instance.player != null)
            this.Player_life.text = game2.instance.player.bird_life.ToString();
    }

    public void updateScore(int score)
    {
        this.Player_life.text = score.ToString();
    }

    public void UpdatePanel()
    {
        this.ReadyPanel.SetActive(game2.instance.staue == GAME_STAUE.Ready);
        this.InGamePanel.SetActive(game2.instance.staue == GAME_STAUE.InGame);
        this.GameOverPanel.SetActive(game2.instance.staue == GAME_STAUE.GameOver);

    }

    public void ShowLevelStart(string name)
    {
        this.uiShowName.text = name;
        this.uiTextName.text = name;
        UILevelStart.SetActive(true);
    }
}
