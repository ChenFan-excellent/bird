using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : element
{
    public Transform target;
    private bool running = false;

    protected override void OnUpdate()
    {
        Vector3 dir = (target.transform.position - this.transform.position).normalized;
        this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        this.transform.position += speed * Time.deltaTime * dir;
    }
    public void Launch()
    {
        running = true;
    }
}
