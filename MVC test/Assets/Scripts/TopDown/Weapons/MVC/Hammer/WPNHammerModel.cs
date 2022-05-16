using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNHammerModel : WeaponModel
{
    WPNHammerView V;

    protected override void Awake()
    {
        base.Awake();
        V = GetComponentInChildren<WPNHammerView>();
        if(V != null)
            V.HUD.charge = chargeTime;
    }
    protected override void StartCharge()
    {
        if (!IsCharged)
        {
            currentChargeTime += Time.deltaTime;
            if (currentChargeTime >= chargeTime)
            {
                currentChargeTime = chargeTime;
                onEndCharge();
            }
        }
    }

    protected override void EndCharge()
    {
        IsCharged = true;
        V.charged = IsCharged;
        currentChargeTime = chargeTime;
        currentChargeTime = 0;
    }

    protected override void StopCharge()
    {
        if (IsCharged)
            onUse();
        currentChargeTime = 0;
    }

    protected override void Use()
    {
        var B = Instantiate(projectilePFs[0], projectileSpawns[0].transform.position, projectileSpawns[0].transform.rotation);
        B.dmg = currentDMG;
        B.owner = owner.gameObject;
        currentChargeTime = 0;
        onEndUse();
    }

    protected override void EndUse()
    {
        IsCharged = false;
        V.charged = IsCharged;
    }
}
