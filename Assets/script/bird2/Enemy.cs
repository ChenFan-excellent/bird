using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : unit
{    
    public ENEMY_TYPE enemy_type;

    public Vector2 Range;
    public event DeathNotify onDeath;
    public float init_y = 0;
    // Start is called before the first frame update
    override protected void OnStart()
    {
        this.Flying();
        init_y = Random.Range(-Range.x, Range.y);
        this.transform.localPosition = new Vector3(0, init_y, 0);
        side = SIDE.enemy;
    }

    // Update is called once per frame
    override protected void OnUpdate()
    {       
        float y = 0;
        if(enemy_type == ENEMY_TYPE.Swing)
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad) * 3f;
        }

        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed, init_y + y, 0);

        this.Fire();

    }
    
    public void deathani()
    {
        this.animationBird.SetTrigger("enemydie");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy: OnCollisionEnter2D :" + collision.gameObject.name + " : " + gameObject.name);
        //Death();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        element bullet = collision.gameObject.GetComponent<element>();
        if (bullet == null)
        {
            return;
        }
        Debug.Log("Enemy: OnTriggerEnter2D : " + collision.gameObject.name + " : " + gameObject.name);
        if (bullet.side == SIDE.player)
        {
            this.Death();          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enemy: OnTriggerExit2D : " + collision.gameObject.name + " : " + gameObject.name);
        if (collision.gameObject.name == "ScoreArea")
        {
            if (this.getScore != null)
            {
                this.getScore(1);
            }
        }
    }
    private void Death()
    {
        this.isDeath = true;
        
        if (this.onDeath != null)
        {
            this.onDeath();
        }
        deathani();
        Destroy(this.gameObject,0.3f);
    }   
}
