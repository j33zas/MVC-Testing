using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordModel : WeaponModel
{
    protected override void Awake()
    {
        base.Awake();
        owner = GetComponentInParent<TopDownPlayerModel>();
    }
    protected override void Use()
    {
        base.Use();
        var s = Instantiate(projectilePFs[0], projectileSpawns[0].position, projectileSpawns[0].rotation);
        s.transform.up = projectileSpawns[0].transform.up;
        s.owner = owner.gameObject;
        s.dmg = currentDMG;
    }
}
