using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeWeaponHUD : MonoBehaviour
{
    [SerializeField] Image fillCharge;
    [SerializeField] Gradient gradientCharge;
    float currentCharge;
    float _totalCharge;
    public float charge
    {
        get
        {
            return _totalCharge;
        }
        set
        {
            _totalCharge = value;
        }
    }
    public void SetCharge()
    {
        currentCharge += Time.deltaTime;
        fillCharge.fillAmount = (currentCharge / _totalCharge);
        fillCharge.color = gradientCharge.Evaluate(currentCharge / _totalCharge);
    }
    public void ResetCharge()
    {
        currentCharge = 0;
        fillCharge.fillAmount = 0;
    }
}
