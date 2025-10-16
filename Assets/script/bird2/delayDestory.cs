using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayDestory : MonoBehaviour
{
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(false);
    }
}
