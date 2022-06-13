using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNSwordView : WeaponView
{
    public override void UseView()
    {
        if (!usable)
            return;

        base.UseView();
        _SR.flipY = !_SR.flipY;
        _SR.color = Color.cyan;
        StartCoroutine(DelayChangeColor(.1f));
        CameraController.controller.CameraShake(numebrOfCameraShakes, cameraShakeIntensity, cameraShakeTime, new Vector2(1, 1));
    }
    public override WeaponView EnableView()
    {
        if (!_SR)
            _SR = GetComponent<SpriteRenderer>();
        _SR.enabled = true;
        return base.EnableView();
    }
    public override WeaponView DisableView()
    {
        _SR.enabled = false;
        return base.DisableView();
    }
    IEnumerator DelayChangeColor(float time)
    {
        yield return new WaitForSeconds(time);
        _SR.color = Color.white;
    }
}
