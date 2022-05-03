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
        StartCoroutine(Shake(1f,.3f));
    }
    public override void StartChargeView()
    {
        if (!charged)
        {
            _AN.SetBool("Charging", true);
        }
    }
    public override void StopChargeView()
    {
        charged = false;
        _AN.SetTrigger("StoppedCharge");
        _AN.SetBool("Charging", false);
    }
    public override void UseView()
    {
        _AN.SetTrigger("Shoot");
    }
    public override void EndUseView()
    {
        _AN.SetBool("Charging", false);
    }
    IEnumerator Shake(float intensity, float interval, int mult = 1)
    {
        transform.position += new Vector3(0, 1) * mult * intensity * Time.deltaTime;
        yield return new WaitForSeconds(interval);
        StartCoroutine(Shake(intensity, interval, -mult));
    }
}
