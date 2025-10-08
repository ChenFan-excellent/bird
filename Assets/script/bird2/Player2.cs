using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Player2 : MonoBehaviour
{
    public Rigidbody2D rigidbodyBird;
    public float speed = 100f;
    public Animator animationBird;
    public bool isDeath = false;
    public delegate void DeathNotify();
    public event DeathNotify onDeath;
    private Vector3 birdpos;
    public UnityAction <int> getScore;

    public GameObject bulletTemplate;

    public float fireRate = 10f;

    public float HP = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animationBird = GetComponent<Animator>();
        this.Idel();
        birdpos = this.transform.position;
    }

    float fireTimer = 0;
    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (isDeath == true)
            return;
        Vector2 pos = this.transform.position;
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Debug.Log(Input.GetAxis("Horizontal") + ", " + Input.GetAxis("Vertical"));

        this.transform.position = pos;
        if(Input.GetButton("Fire1"))
        {
            this.Fire();
        }
    }
    public void Fire()
    {
        if (fireTimer > 1f / fireRate)
        {
            GameObject go = Instantiate(bulletTemplate);
            go.transform.position = this.transform.position;

            fireTimer = 0f;
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

    public void BeginPlayable()
    {
        this.isDeath = false;

        if (rigidbodyBird != null)
        {
            rigidbodyBird.simulated = true;
            rigidbodyBird.velocity = Vector2.zero;
        }
        animationBird.ResetTrigger("Idel");
        animationBird.ResetTrigger("death");
        animationBird.ResetTrigger("Flying");
        animationBird.Play("Flying", 0, 0f);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player:OnCollisionEnter2D :" + collision.gameObject.name + " : " + gameObject.name);
        //Death();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        element bullet = collision.gameObject.GetComponent<element>();
        if (bullet == null)
        {
            return;
        }
        Debug.Log("Player: OnTriggerEnter2D : " + collision.gameObject.name + " : " + gameObject.name);
        if(bullet.side == SIDE.enemy)
        {
            this.HP -= bullet.power;
            if(HP <= 0)
            {
                this.Death();
            }
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
    public void init()
    {
        this.transform.position = birdpos;
        Idel();
        this.isDeath = false;        
    }
}
