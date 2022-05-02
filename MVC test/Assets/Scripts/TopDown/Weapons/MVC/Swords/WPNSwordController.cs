using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordController : WeaponController
{
    public WPNSwordController(WeaponModel M, WeaponView V, TopDownPlayerModel P) : base(M, V, P)
    {

    }

    public override void Listener()
    {
        base.Listener();
        if(Input.GetMouseButtonDown(0))
        {
            _M.onUse();
        }
    }
}
