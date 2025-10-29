using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayDestory : MonoBehaviour
{
    public float delay = 1f;
    private Coroutine co;                 

    void OnEnable()                      
    {
        co = StartCoroutine(Delay());
    }

    void OnDisable()                      
    {
        if (co != null) StopCoroutine(co);
        co = null;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(delay); 
        gameObject.SetActive(false);
    }
}
