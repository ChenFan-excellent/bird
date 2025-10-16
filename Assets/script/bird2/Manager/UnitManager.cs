using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoSingleton<UnitManager>
{
    public List<Enemy> enemies = new List<Enemy>();

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
    public void init()
    {

    }

    public void Clear()
    {
        this.enemies.Clear();
    }
}
