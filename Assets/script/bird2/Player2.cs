using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Player2 : unit
{
    public event DeathNotify onDeath;
    // Start is called before the first frame update
    override protected void OnStart()
    {
        this.Idel();
        side = SIDE.player;
    }

    // Update is called once per frame
    override protected void OnUpdate()
    {      
        Vector2 pos = this.transform.position;
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;    

        this.transform.position = pos;
        if(Input.GetButton("Fire1"))
        {
            this.Fire();
        }
    }
    
    public void deathani()
    {
        this.animationBird.SetTrigger("death");
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player:OnCollisionEnter2D :" + collision.gameObject.name + " : " + gameObject.name);
        //Death();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        element bullet = collision.gameObject.GetComponent<element>();
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (bullet == null && enemy == null)
        {
            return;
        }
        Debug.Log("Player: OnTriggerEnter2D : " + collision.gameObject.name + " : " + gameObject.name);
        if(bullet != null&&bullet.side == SIDE.enemy)
        {
            this.HP -= bullet.power;
            if(HP <= 0)
            {
                this.Death();
            }
        }
        if(enemy != null)
        {
            this.HP =0;           
            this.Death();           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player: OnTriggerExit2D : " + collision.gameObject.name + " : " + gameObject.name);
        if (collision.gameObject.name == "ScoreArea")
        {
            if(this.getScore != null)
            {
                this.getScore(1);
            }
        }      
    }
    private void Death()
    {
        this.isDeath = true;
        if(this.onDeath != null)
        {
            this.onDeath();
        }
    }    
}
