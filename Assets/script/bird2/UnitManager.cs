using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject enemyTemplate;
    public GameObject enemyTemplate2;
    public GameObject enemyTemplate3;

    public List<Enemy> enemies = new List<Enemy>();

    Coroutine coroutine = null;

    public float speed1 = 1f;
    public float speed2 = 3f;
    public float speed3 = 5f;

    public void Begin()
    {
        //coroutine = StartCoroutine(generateEnemies());
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
    float timer1 = 0f;
    float timer2 = 0f;
    float timer3 = 0f;
    IEnumerator generateEnemies()
    {      
        while(true)
        {
            if(timer1 >= speed1)
            {
                CreateEnemy(enemyTemplate);
                timer1 = 0f;
            }
            if (timer2 >= speed2)
            {
                CreateEnemy(enemyTemplate2);
                timer2 = 0f;
            }
            if (timer3 >= speed3)
            {
                CreateEnemy(enemyTemplate3);
                timer3 = 0f;
            }
            timer1++;
            timer2++;
            timer3++;
            yield return new WaitForSeconds(1f);
        }
    }
    public void stop()
    {
        //StopCoroutine(coroutine);
        //this.enemies.Clear();
    }
}
