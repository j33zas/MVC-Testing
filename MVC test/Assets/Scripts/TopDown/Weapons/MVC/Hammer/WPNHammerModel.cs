using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNHammerModel : WeaponModel
{
    protected override void Start()
    {
        base.Start();
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
        B.Dmg = currentDMG;
        B.Owner = owner.gameObject;
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
    public override WeaponModel EnableModel()
    {
        if(!owner)
            owner = GetComponentInParent<TopDownPlayerModel>();
        if(!V)
        {
            V = GetComponentInChildren<WPNHammerView>();
            V.HUD.charge = chargeTime;
        }
        return base.EnableModel();
    }
    public override WeaponModel DisableModel()
    {
        Destroy(gameObject);
        return base.DisableModel();
    }
}
