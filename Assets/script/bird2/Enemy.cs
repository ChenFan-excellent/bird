using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidbodyBird;
    public float speed = 100f;
    public Animator animationBird;
    public bool isDeath = false;
    public delegate void DeathNotify();
    public event DeathNotify onDeath;
    private Vector3 birdpos;
    public UnityAction<int> getScore;
    public float lifetime = 30f;

    public GameObject bulletTemplate;

    public ENEMY_TYPE enemy_type;

    public Vector2 Range;

    public float init_y = 0;

    public float fireRate = 10f;
    // Start is called before the first frame update
    void Start()
    {
        animationBird = GetComponent<Animator>();
        this.Flying();
        birdpos = this.transform.position;
        init_y = Random.Range(-Range.x, Range.y);
        this.transform.localPosition = new Vector3(0, init_y, 0);
    }

    float fireTimer = 0;
    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (isDeath == true)
            return;
        float y = 0;
        if(enemy_type == ENEMY_TYPE.Swing)
        {
            y = Mathf.Sin(Time.timeSinceLevelLoad) * 3f;
        }

        this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed, init_y + y, 0);

        this.Fire();

    }
    public void Fire()
    {
        if (fireTimer > 1f / fireRate)
        {
            GameObject go = Instantiate(bulletTemplate);
            go.transform.position = this.transform.position;
            go.GetComponent<element>().direction = - 1;            
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
        this.animationBird.SetTrigger("enemydie");
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
    public void init()
    {
        this.transform.position = birdpos;
        Idel();
        this.isDeath = false;
    }
}
