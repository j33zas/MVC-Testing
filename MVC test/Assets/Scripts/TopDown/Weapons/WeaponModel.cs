using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    #region Actions
    public Action onStartCharge;
    public Action onStopCharge;
    public Action onEndCharge;
    public Action onUse;
    public Action onEndUse;
    public Action onStartCoolDown;
    public Action onEndCoolDown;
    public Action onKill;
    public Action onHit;
    public Action onMiss;
    public Action onPickUp;
    public Action onDrop;
    public Action onEquip;
    #endregion

    #region stats
    [SerializeField] protected float useCD;
    protected float currentCD;
    [SerializeField] protected int DMG;
    protected int currentDMG;
    [SerializeField] protected HitBox[] projectilePFs;
    [SerializeField] protected Transform[] projectileSpawns;
    [SerializeField] protected float chargeTime = 0;
    protected float currentChargeTime;
    protected bool IsCharged;
    [SerializeField] protected string description;
    [SerializeField] protected string WPNName;
    #endregion

    #region MVC
    [SerializeField] protected WeaponView _WV;
    [SerializeField] protected WeaponController _WC;
    #endregion

    #region Functions
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {

    }
    protected virtual void StartCharge()
    {

    }
    protected virtual void StopCharge()
    {

    }
    protected virtual void EndCharge()
    {

    }
    protected virtual void Use()
    {

    }
    protected virtual void EndUse()
    {

    }
    protected virtual void StartCoolDown()
    {

    }
    protected virtual void EndCoolDown()
    {

    }
    protected virtual void Kill()
    {

    }// !!!
    protected virtual void Hit()
    {

    }
    protected virtual void Miss()
    {

    }
    protected virtual void PickUp()
    {

    }
    protected virtual void Drop()
    {

    }
    protected virtual void Equip()
    {

    }
    #endregion

    public WeaponModel()
    {
        onStartCharge += StartCharge;
        onStopCharge += StopCharge;
        onEndCharge += EndCharge;
        onUse += Use;
        onEndUse += EndUse;
        onStartCoolDown += StartCoolDown;
        onEndCoolDown += EndCoolDown;
        onKill += Kill;
        onHit += Hit;
        onMiss += Miss;
        onPickUp += PickUp;
        onDrop += Drop;
        onEquip += Equip;
    }

}
