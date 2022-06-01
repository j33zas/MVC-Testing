using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordController : WeaponController
{
    public WPNSwordController(WeaponModel M, WeaponView V) : base(M, V)
    {

    }

    public override void Listener()
    {
        base.Listener();
        if(Input.GetMouseButtonDown(0))
        {
            _M.onUse();
        }
        _M.OnLook(Camera.main.ScreenToWorldPoint(Input.mousePosition), _P.transform.position);
    }
}
