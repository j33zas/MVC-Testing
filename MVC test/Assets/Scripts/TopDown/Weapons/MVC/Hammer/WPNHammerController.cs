using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNHammerController : WeaponController
{
    public WPNHammerController(WeaponModel M, WeaponView V) : base(M, V)
    {

    }

    public override void Listener()
    {
        base.Listener();
        if (Input.GetMouseButton(0))
            _M.onStartCharge();

        if (Input.GetMouseButtonUp(0))
            _M.onStopCharge();

        _M.OnLook(Camera.main.ScreenToWorldPoint(Input.mousePosition), _P.transform.position);
    }
}
