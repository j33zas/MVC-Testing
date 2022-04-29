using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowController : WeaponController
{
    public WPNBowController(WeaponModel M, WeaponView V) : base(M, V){}

    public override void Listener()
    {
        if(Input.GetMouseButton(0))
            _M.onStartCharge();

        if (Input.GetMouseButtonUp(0))
            _M.onStopCharge();

    }
}
