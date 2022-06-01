using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordModel : WeaponModel
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Use()
    {
        if (canBeUsed)
        {
            var s = Instantiate(projectilePFs[0], projectileSpawns[0].position, projectileSpawns[0].rotation);
            s.transform.up = projectileSpawns[0].transform.up;
            s.owner = owner.gameObject;
            s.dmg = currentDMG;
            onEndUse();
        }
    }
    protected override void EndUse()
    {
        currentCD = useCD;
    }
}
