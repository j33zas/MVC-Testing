using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowView : WeaponView
{

    public override void LookAtView(Vector3 point, Vector3 positionRef)
    {
        if(point.y < positionRef.y)
            _SR.sortingLayerName = "AbovePlayer";
        else if(point.y > positionRef.y)
            _SR.sortingLayerName = "BehindPlayer";
    }
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
