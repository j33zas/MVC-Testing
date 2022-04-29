using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowView : WeaponView
{
    public override void EndChargeView()
    {
        _SR.color = Color.red;
    }
    public override void StartChargeView()
    {
        if (!charged)
            _SR.color = Color.blue;
    }
    public override void StopChargeView()
    {
        _SR.color = Color.white;
        charged = false;
    }
    public override void UseView()
    {
        if(charged)
            _SR.color = Color.black;
    }
    public override void EndUseView()
    {
        _SR.color = Color.white;
    }
}
