using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlpelineManager2 : MonoSingleton<PlpelineManager2>
{
    public GameObject Plpeline;
    Coroutine coroutine = null;
    List<Plpeline2> Plpelines = new List<Plpeline2>();
    
    public void init()
    {
        for (int i = 0; i < Plpelines.Count; i++)
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
            Plpeline2 p = obj.GetComponent<Plpeline2>();
            Plpelines.Add(p);
        }

    }
    IEnumerator generatePlpelines()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Plpelines.Count < 3)
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
        for (int i = 0; i < Plpelines.Count; i++)
        {
            Plpelines[i].enabled = false;
        }
    }
}

