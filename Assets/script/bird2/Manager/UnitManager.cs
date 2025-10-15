using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoSingleton<UnitManager>
{
    public GameObject enemyTemplate;
    public GameObject enemyTemplate2;
    public GameObject enemyTemplate3;

    public List<Enemy> enemies = new List<Enemy>();

    public void Begin()
    {
        
    }
    public Enemy CreateEnemy(GameObject template)
    {
        if (template == null)
        {
            return null;
        }
        GameObject obj = Instantiate(template, this.transform);
        Enemy p = obj.GetComponent<Enemy>();
        enemies.Add(p);
        return p;
    }
    
    public void stop()
    {

    }
}
