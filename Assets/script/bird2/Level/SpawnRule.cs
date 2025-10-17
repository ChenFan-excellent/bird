using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    public unit Monster;
    public int InitTime;
    public float Period;
    public int MaxNum;

    public int HP;
    public float attack;

    float timeSinceLevelStart = 0;
    float levelStartTime = 0;

    float timer = 0;

    public ItemDropRule droprule;
    ItemDropRule rule;

    // Start is called before the first frame update
    void Start()
    {
        this.levelStartTime = Time.realtimeSinceStartup;
        if (droprule != null)
            rule = Instantiate<ItemDropRule>(droprule);
    }

    int num = 0;

    // Update is called once per frame
    void Update()
    {
        timeSinceLevelStart = Time.realtimeSinceStartup - this.levelStartTime;

        if (num >= MaxNum)
            return;

        if(timeSinceLevelStart > InitTime)
        {
            timer += Time.deltaTime;

            if(timer > Period)
            {
                Enemy enemy = UnitManager.instance.CreateEnemy(this.Monster.gameObject);
                enemy.MaxHP = this.HP;
                enemy.attack = this.attack;
                timer = 0;
                enemy.onDeath += Enemy_OnDeath;
                num++;
            }
        }
    }

    private void Enemy_OnDeath(unit sender)
    {
        if (rule != null)
            rule.Execute(sender.transform.position);
    }
}
