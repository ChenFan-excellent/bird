using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public GameObject missileTemplate;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public Transform battery;

    private Missile missile = null;

    public unit target;

    override protected void OnStart()
    {
        this.Flying();
        StartCoroutine(FireMissile());
        StartCoroutine(Fire2());
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
