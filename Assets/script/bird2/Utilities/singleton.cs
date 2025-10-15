using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton<T> where T : new()
{
    static T Instance;

    public static T instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new T();
            }
            return Instance;
        }
    }
}
