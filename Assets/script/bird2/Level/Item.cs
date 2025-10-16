using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int AddHP = 50;

    public GameObject bullet;

    public float lifeTime = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, -1f, 0) * Time.deltaTime;
    }

    public void Use(unit target)
    {
        target.AddHP(this.AddHP);
        Destroy(this.gameObject);
    }
}
