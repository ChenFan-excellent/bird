using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class unit : MonoBehaviour
{
    protected SIDE side;

    public Rigidbody2D rigidbodyBird;
    public float speed = 100f;
    public Animator animationBird;
    protected bool isDeath = false;

    public float fireRate = 10f;

    public delegate void DeathNotify();
    protected Vector3 birdpos;
    public UnityAction<int> getScore;

    public GameObject bulletTemplate;

    public float HP = 10f;
    public float MaxHP = 10f;

    float fireTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        animationBird = GetComponent<Animator>();
        birdpos = this.transform.position;
        OnStart();
    }

    protected virtual void OnStart()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (isDeath == true)
            return;
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {

    }

    public void init()
    {
        this.transform.position = birdpos;
        Idel();
        this.isDeath = false;
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
    public void Fire()
    {
        if (fireTimer > 1f / fireRate)
        {
            GameObject go = Instantiate(bulletTemplate);
            go.transform.position = this.transform.position;
            go.GetComponent<element>().direction = side == SIDE.player ? 1 : -1;
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
}
