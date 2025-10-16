using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public int LevelID;
    public string Name;

    public Boss Boss;

    public UnityAction<LEVEL_RESULT> OnLevelEnd;

    public List<SpawnRule> Rules = new List<SpawnRule>();



    float bossTime = 60f;

    float timeSinceLevelStart = 0;
    float levelStartTime = 0;

    Boss boss = null;


    public enum LEVEL_RESULT
    {
        NONE,
        SUCCESS,
        FAIL
    }
    public LEVEL_RESULT result = LEVEL_RESULT.NONE;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowLevelStart());
        for(int i =0; i<Rules.Count;i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.result == LEVEL_RESULT.SUCCESS)
            return;

        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (timeSinceLevelStart > bossTime)
        {
            if(boss == null)
            {
                boss = (Boss)UnitManager.instance.CreateEnemy(this.Boss.gameObject);
                boss.target = game2.instance.player;
                boss.onDeath += Boss_true_onDeath;
            }
        }
    }

    private void Boss_true_onDeath()
    {
        this.result = LEVEL_RESULT.SUCCESS;
        if(this.OnLevelEnd != null)
        {
            this.OnLevelEnd(this.result);
        }
    }

    IEnumerator ShowLevelStart()
    {
        UIManager.instance.ShowLevelStart(string.Format("LEVEL{0} {1}", this.LevelID, this.Name));
        yield return new WaitForSeconds(2f);
    }

}
