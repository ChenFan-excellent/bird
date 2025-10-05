using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbodyBird;
    public float force = 100f;
    public Animator animationBird;
    public bool isDeath = false;
    public delegate void DeathNotify();
    public event DeathNotify onDeath;
    private Vector3 birdpos;
    public UnityAction <int> getScore;
    // Start is called before the first frame update
    void Start()
    {
        animationBird = GetComponent<Animator>();
        this.Idel();
        birdpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath == true)
            return;
        if(Input.GetMouseButton(0))
        {
            rigidbodyBird.velocity = Vector2.zero;
            rigidbodyBird.AddForce(new Vector2(0, force));
        }
    }
    public void Idel()
    {
        this.rigidbodyBird.simulated = false;
        this.animationBird.SetTrigger("Idel");
    }
    public void Flying()
    {
        this.animationBird.SetTrigger("Flying");
        this.rigidbodyBird.simulated = true;
    }
    public void deathani()
    {
        this.animationBird.SetTrigger("death");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Death();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ScoreArea")
        {
            return;
        }
        Death();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
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
    public void init()
    {
        this.transform.position = birdpos;
        Idel();
        this.isDeath = false;        
    }
}
