using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNHammerModel : WeaponModel
{
    WPNHammerView V;
    protected override void Start()
    {
        base.Start();
        V = GetComponentInChildren<WPNHammerView>();
        if(V)
            V.HUD.charge = chargeTime;
        owner = GetComponentInParent<TopDownPlayerModel>();
    }

    protected override void StartCharge()
    {
        if (!IsCharged && canBeUsed)
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
        var B = Instantiate(projectilePFs[0], projectileSpawns[0].transform.position, Quaternion.identity);
        B.dmg = currentDMG;
        B.owner = owner.gameObject;
        currentChargeTime = 0;
        onEndUse();
    }

    protected override void EndUse()
    {
        IsCharged = false;
        V.charged = IsCharged;
        currentCD = useCD;
        V.usable = false;
    }
    protected override void StartCoolDown()
    {
        base.StartCoolDown();
        V.usable = false; 
    }
    protected override void EndCoolDown()
    {
        base.EndCoolDown();
        V.usable = true;
    }
}
