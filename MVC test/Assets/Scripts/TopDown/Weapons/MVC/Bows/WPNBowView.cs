using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowView : WeaponView
{

    Vector3 startPos = Vector3.zero;
    void Awake()
    {
        currentChargeWPNCanvas = Instantiate(chargeWPNCanvas,transform.parent);
    }

    public override void EndChargeView()
    {
        StartCoroutine(ShakeMe(WPNShakeForce,WPNShakeInterval));
    }
    public override void StartChargeView()
    {
        if (!charged)
        {
            _AN.SetBool("Charging", true);
            currentChargeWPNCanvas.SetCharge();
        }
    }
    public override void StopChargeView()
    {
        charged = false;
        _AN.SetTrigger("StoppedCharge");
        _AN.SetBool("Charging", false);
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
        Debug.Log("stopped using");
    }

}
