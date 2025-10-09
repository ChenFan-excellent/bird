using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class element : MonoBehaviour
{
    public float speed = 10f;

    public SIDE side;

    public int direction = 1;

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
        this.transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
        if (!Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)))
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
