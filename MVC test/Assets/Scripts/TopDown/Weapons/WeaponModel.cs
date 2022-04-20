using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    #region Actions
    public Action onStartCharge;
    public Action onEndCharge;
    public Action onUse;
    public Action onEndUse;
    public Action onStartCoolDown;
    public Action onEndCoolDown;
    public Action onKill;
    public Action onMiss;
    public Action onPickUp;
    public Action onDrop;
    public Action onEquip;
    #endregion

    #region stats
    [SerializeField] protected float useCD;
    [SerializeField] protected int damage;
    [SerializeField] protected HitBox[] projectilePFs;
    [SerializeField] protected Transform[] projectileSpawns;
    [SerializeField] protected float chargeTime = 0;
    [SerializeField] protected string description;
    [SerializeField] protected string WPNname;
    #endregion

    #region MVC
    [SerializeField] protected WeaponView _WV;
    [SerializeField] protected WeaponController _WC;
    #endregion

    public WeaponModel()
    {

    }
}
