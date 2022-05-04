using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowView : WeaponView
{
    [SerializeField] float shakeInterval;
    [SerializeField] float shakeForce;
    Vector3 startPos = Vector3.zero;
    void Awake()
    {
        currentChargeWPNCanvas = Instantiate(chargeWPNCanvas,transform.parent);
    }

    public override void EndChargeView()
    {
        StartCoroutine(Shake(shakeForce,shakeInterval));
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
    }
    public override void EndUseView()
    {
        _AN.SetBool("Charging", false);
        StopAllCoroutines();
        transform.localPosition = startPos;
        currentChargeWPNCanvas.ResetCharge();
        Debug.Log("stopped using");
    }
    IEnumerator Shake(float intensity, float interval, int mult = 1)
    {
        transform.position += new Vector3(0, 1) * mult * intensity;
        yield return new WaitForSeconds(interval);
        StartCoroutine(Shake(intensity, interval, -mult));
    }
}
