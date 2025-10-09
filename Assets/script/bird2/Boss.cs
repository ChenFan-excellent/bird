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
    }

    IEnumerator FireMissile()
    {
        yield return new WaitForSeconds(5f);
        animationBird.SetTrigger("BossSkill");
    }

    override protected void OnUpdate()
    {

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
