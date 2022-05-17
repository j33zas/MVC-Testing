using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNHammerView : WeaponView
{
    [SerializeField] float rotateSpeed;
    Vector3 startPos;
    protected override void Start()
    {
        base.Start();
        currentChargeWPNCanvas = Instantiate(chargeWPNCanvas, transform.parent.parent);
        startPos = Vector3.zero;
    }

    public override void StartChargeView()
    {
        if (!charged && usable)
        {
            currentChargeWPNCanvas.SetCharge();
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotateSpeed);
        }
    }

    public override void StopChargeView()
    {
        charged = false;
        currentChargeWPNCanvas.ResetCharge();
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public override void EndChargeView()
    {
        StartCoroutine(ShakeMe(WPNShakeForce, WPNShakeInterval));
    }
    public override void UseView()
    {
        CameraController.controller.CameraShake(numebrOfCameraShakes, cameraShakeIntensity, cameraShakeTime, new Vector2(1, 1));
    }
    public override void EndUseView()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.Rotate(0, 0, -50);
        transform.localPosition = startPos;
        currentChargeWPNCanvas.ResetCharge();
        StopAllCoroutines();
    }
}
