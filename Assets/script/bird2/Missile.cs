using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Element
{
    public Transform target;
    private bool running = false;

    public float damage = 20f;
    public GameObject Fxexplod;

    protected override void OnUpdate()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        if(dir.magnitude <= 0.1)
        {
            this.Explod();
        }
        this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        this.transform.position += speed * Time.deltaTime * dir.normalized;
    }
    public void Launch()
    {
        running = true;
    }

    public void Explod()
    {
        Destroy(this.gameObject);
        Instantiate(Fxexplod, this.transform.position, Quaternion.identity);

        if (target!= null)
        {
            Player2 player = target.GetComponent<Player2>();
            player.Damage(damage);
        }
    }
}
