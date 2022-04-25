using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordModel : WeaponModel
{
    protected override void Use()
    {
        base.Use();
        Instantiate(projectilePFs[0], projectileSpawns[0].position, projectileSpawns[0].rotation);
        
    }
}
