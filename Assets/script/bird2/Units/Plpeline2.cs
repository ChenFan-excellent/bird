using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plpeline2 : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    private float t = 0;
    void Start()
    {
        this.init();
    }
    public void init()
    {
        float y = Random.Range(-1.7f, 4.3f);
        this.transform.localPosition = new Vector3(0, y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-Speed, 0, 0) * Time.deltaTime;
        t += Time.deltaTime;
        if(t>7.5f)
        {
            t = 0;
            this.init();
        }
    }
}
