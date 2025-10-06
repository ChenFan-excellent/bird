using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlpelineManager : MonoBehaviour
{
    public GameObject Plpeline;
    Coroutine coroutine = null;
    List<Plpeline> Plpelines = new List<Plpeline>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void init()
    {
        for(int i = 0; i < Plpelines.Count; i++)
        {
            Destroy(Plpelines[i].gameObject);
        }
        Plpelines.Clear();
    }
    public void generatePlpeline()
    {
        if (Plpelines.Count < 3)
        {
            GameObject obj = Instantiate(Plpeline, this.transform);
            Plpeline p = obj.GetComponent<Plpeline>();
            Plpelines.Add(p);
        }
       
    }
    IEnumerator generatePlpelines()
    {
        for (int i = 0; i < 3; i++)
        {
            if(Plpelines.Count < 3)
              generatePlpeline();
            else
            {
                Plpelines[i].enabled = true;
                Plpelines[i].init();
            }

            yield return new WaitForSeconds(2.5f);
        }
    }
    public void startRun()
    {        
        coroutine = StartCoroutine(generatePlpelines());       
    }
    public void stop() 
    {
        StopCoroutine(coroutine);
        for(int i = 0; i < Plpelines.Count; i++)
        {
            Plpelines[i].enabled = false;
        }
    }
}
