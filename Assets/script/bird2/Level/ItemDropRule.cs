using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropRule : MonoBehaviour
{
    public Item item;
    public float dropRatio;

    public void Execute(Vector3 pos)
    {
        if(UnityEngine.Random.Range(0f,100f)<dropRatio)
        {
            Item rule = Instantiate<Item>(item);
            rule.transform.position = pos;
        }
    }
}
