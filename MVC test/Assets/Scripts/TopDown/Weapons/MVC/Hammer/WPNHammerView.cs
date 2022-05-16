using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNHammerView : WeaponView
{
    [SerializeField] float rotateSpeed;
    protected override void Start()
    {
        base.Start();
        currentChargeWPNCanvas = Instantiate(chargeWPNCanvas, transform.parent);    
    }
    public override void StartChargeView()
    {
        if (!charged)
        {
            currentChargeWPNCanvas.SetCharge();
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed);
        }
    }

    public override void StopChargeView()
    {
        charged = false;
        currentChargeWPNCanvas.ResetCharge();
    }

    public override void EndChargeView()
    {
        base.EndChargeView();
        StartCoroutine(ShakeMe(WPNShakeForce, WPNShakeInterval));
    }
    public override void UseView()
    {
        base.UseView();
        CameraController.controller.CameraShake(numebrOfCameraShakes, cameraShakeIntensity, cameraShakeTime, new Vector2(1, 1));
    }
}
