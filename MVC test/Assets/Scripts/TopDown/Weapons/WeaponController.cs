using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : IWeaponController
{
    protected WeaponModel _M;
    protected WeaponView _V;
    public WeaponController(WeaponModel M, WeaponView V)
    {
        _M = M;
        _V = V;
        _M.onDrop += _V.DropView;
        _M.onEndCharge += _V.EndChargeView;
        _M.onEndCoolDown += _V.EndCoolDownView;
        _M.onEndUse += _V.EndUseView;
        _M.onEquip += _V.EquipView;
        _M.onKill += _V.KillEnemyView;
        _M.onHit += _V.HitView;
        _M.onMiss += _V.MissView;
        _M.onPickUp += _V.PickUpView;
        _M.onStartCharge += _V.StartChargeView;
        _M.onStartCoolDown += _V.StartCoolDownView;
        _M.onUse += _V.UseView;
    }
    public virtual void Listener()
    {

    }
}
