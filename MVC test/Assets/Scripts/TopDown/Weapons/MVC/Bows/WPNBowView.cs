using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowView : WeaponView
{

    Vector3 startPos = Vector3.zero;
    void Awake()
    {
        currentChargeWPNCanvas = Instantiate(chargeWPNCanvas,transform.parent.parent);
    }

    public override void EndChargeView()
    {
        StartCoroutine(ShakeMe(WPNShakeForce,WPNShakeInterval));
        StopParticle("Charge");
        PlayParticle("Charged");
    }
    public override void StartChargeView()
    {
        if (!charged && usable)
        {
            _AN.SetBool("Charging", true);
            if(!GetParticle("Charge").isPlaying)
                PlayParticle("Charge");
            currentChargeWPNCanvas.SetCharge();
        }
    }
    public override void StopChargeView()
    {
        charged = false;
        _AN.SetTrigger("StoppedCharge");
        _AN.SetBool("Charging", false);
        StopParticle("Charge");
        currentChargeWPNCanvas.ResetCharge();
    }
    public override void UseView()
    {
        _AN.SetTrigger("Shoot");
        CameraController.controller.CameraShake(numebrOfCameraShakes, cameraShakeIntensity, cameraShakeTime , new Vector2(1, 1));
    }
    public override void EndUseView()
    {
        _AN.SetBool("Charging", false);
        StopAllCoroutines();
        transform.localPosition = startPos;
        currentChargeWPNCanvas.ResetCharge();
    }
    public override WeaponView EnableView()
    {
        Debug.Log(currentChargeWPNCanvas);
        if (!currentChargeWPNCanvas)
            currentChargeWPNCanvas = Instantiate(chargeWPNCanvas, transform.parent.parent);
        startPos = Vector3.zero;
        return base.EnableView();
    }
    public override WeaponView DisableView()
    {
        _SR.enabled = false;
        Destroy(currentChargeWPNCanvas.gameObject);
        return base.DisableView();
    }
}
