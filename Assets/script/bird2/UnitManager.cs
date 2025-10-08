using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject enemyTemplate;

    public List<Enemy> enemies = new List<Enemy>();

    Coroutine coroutine = null;

    public float speed = 3f;

    public Vector2 Range;

    public void Begin()
    {
        coroutine = StartCoroutine(generateEnemies());
    }
    public void CreateEnemy()
    {
        GameObject obj = Instantiate(enemyTemplate, this.transform);
        Enemy p = obj.GetComponent<Enemy>();
        enemies.Add(p);

        float y = Random.Range(-Range.x, Range.y);
        obj.transform.localPosition = new Vector3(0, y, 0);

    }
    IEnumerator generateEnemies()
    {      
        while(true)
        {
            CreateEnemy();
            yield return new WaitForSeconds(speed);
        }
    }
    public void stop()
    {
        StopCoroutine(coroutine);
        this.enemies.Clear();
    }
}
