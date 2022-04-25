using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordModel : WeaponModel
{
    protected override void Use()
    {
        base.Use();
        foreach (var item in projectileSpawns)
        {
            Instantiate(projectilePFs[0], item.position, item.rotation);
        }
    }
}
