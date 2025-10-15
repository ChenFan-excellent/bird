using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public float speed = 10f;

    public SIDE side;

    public Vector3 direction = Vector3.zero;

    public int power = 1;

    public float lifetime = 5f;

    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    void Update()
    {
        OnUpdate();
    }
    protected virtual void OnUpdate()
    {
        this.transform.position += speed * Time.deltaTime * direction;

        //GameUtil.Instance.InScreen(this.transform.position);

        //singleton<GameUtil>.Instance.InScreen(this.transform.position);

        //GameUtil util = new GameUtil();
        //util.InScreen(this.transform.position);


        if (!GameUtil.instance.InScreen(this.transform.position))
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
