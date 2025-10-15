using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    public static T instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = (T)FindObjectOfType<T>();
            }
            return Instance;
        }
    }
}
