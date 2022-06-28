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
            s.Owner = owner.gameObject;
            s.Dmg = currentDMG;
            s.knockBack = currentKnockBack;
            onEndUse();
        }
    }
    protected override void EndUse()
    {
        currentCD = useCD;
    }
    public override WeaponModel EnableModel()
    {
        if (!V)
            V = GetComponentInChildren<WeaponView>();
        return base.EnableModel();
    }
    public override WeaponModel DisableModel()
    {
        Destroy(gameObject);
        return base.DisableModel();
    }
}
