using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int LevelID;
    public string Name;

    public Player2 currentPlayer;
    public Boss boss;

    public List<SpawnRule> Rules = new List<SpawnRule>();

    public UnitManager unitManager;

    float timer = 0;

    float bossTime = 60f;

    float timeSinceLevelStart = 0;
    float levelStartTime = 0;

    Boss boss_true = null;

    bool oneboss = false;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<Rules.Count;i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
            rule.unitManager = this.unitManager;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (timeSinceLevelStart > bossTime)
        {
            if(oneboss == false)
            {
                boss_true = (Boss)unitManager.CreateEnemy(this.boss.gameObject);
                boss_true.target = currentPlayer;
                oneboss = true;
            }
        }
    }
}
