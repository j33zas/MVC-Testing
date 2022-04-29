using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordView : WeaponView
{
    public override void UseView()
    {
        base.UseView();
        _SR.flipX = !_SR.flipX;
        _SR.color = Color.cyan;
        StartCoroutine(DelayChangeColor(.1f));
    }

    IEnumerator DelayChangeColor(float time)
    {
        yield return new WaitForSeconds(time);
        _SR.color = Color.white;
    }
}