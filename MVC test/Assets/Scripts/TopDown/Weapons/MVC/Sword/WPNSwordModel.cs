using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordModel : WeaponModel
{
    protected override void Use()
    {
        base.Use();
        var s = Instantiate(projectilePFs[0], projectileSpawns[0].position, projectileSpawns[0].rotation);
        s.transform.localScale = Vector3.one;
        s.dmg = damage;
    }
}
