using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNBowModel : WeaponModel
{
    WPNBowView V;
    public WPNBowModel ():base()
    {    }
    protected override void Start()
    {
        base.Start();
        V = GetComponentInChildren<WPNBowView>();
    }
    protected override void EndCharge()
    {
        IsCharged = true;
        currentChargeTime = chargeTime;
        V.charged = IsCharged;
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
        currentChargeTime = 0;
        onEndUse();
    }
    protected override void EndUse()
    {
        IsCharged = false;
        V.charged = IsCharged;
    }
    protected override void StartCharge()
    {
        if(!IsCharged)
        {
            currentChargeTime += Time.deltaTime;
            if(currentChargeTime >= chargeTime)
            {
                currentChargeTime = chargeTime;
                onEndCharge();
            }
        }
    }
}
