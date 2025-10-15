using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject missileTemplate;

    public Transform firePoint2;
    public Transform firePoint3;

    public Transform battery;

    private Missile missile = null;

    public unit target;


    override protected void OnStart()
    {
        this.Flying();
        StartCoroutine(Enter());
        Attack();
    }

    void Attack()
    {
        StartCoroutine(Fire1());
        StartCoroutine(Fire2());
        StartCoroutine(FireMissile());
    }

    IEnumerator Enter()
    {
        this.transform.position = new Vector3(14, 0, 0);
        yield return MoveTo(new Vector3(9.53f, 0,0));
    }

    IEnumerator Fire1()
    {
        while (true)
        {
            Fire();
            yield return null;
        }
    }

    IEnumerator MoveTo(Vector3 pos)
    {
        while(true)
        {
            Vector3 dir = (pos - this.transform.position);
            if (dir.magnitude <= 0.1)
            {
                break;
            }
            this.transform.position += speed * Time.deltaTime * dir.normalized;
            yield return null;
        }
    }

    IEnumerator FireMissile()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);
            animationBird.SetTrigger("BossSkill");
        }
    }

    IEnumerator Fire2()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 3; i++)
            {
                GameObject go = Instantiate(bulletTemplate, firePoint2.position, battery.rotation);
                Element bullet = go.GetComponent<Element>();
                bullet.direction = (target.transform.position - firePoint2.position).normalized;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    override protected void OnUpdate()
    {
        if(target != null)
        {
            Vector3 dir = (target.gameObject.transform.position - battery.position).normalized;
            battery.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        }
    }

    public void OnMissileLoad()
    {
        GameObject go = Instantiate(missileTemplate, firePoint3);
        missile = go.GetComponent<Missile>();
        missile.target = this.target.transform;
    }
    public void OnMissileLaunch()
    {
        if (missile == null)
            return;
        missile.transform.SetParent(null);
        missile.Launch();
    }
}
