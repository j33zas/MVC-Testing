using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public WeaponClass myWPNType;

    #region Actions
    public Action<Vector3, Vector3> OnLook;
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
    TopDownPlayerModel _O;
    public TopDownPlayerModel owner
    {
        get
        {
            return _O;
        }
        set
        {
            _O = value;
        }
    }
    [SerializeField] protected float useCD;
    protected float currentCD;
    protected bool canBeUsed;
    [SerializeField] protected int DMG;
    protected int currentDMG;
    [SerializeField] protected HitBox[] projectilePFs;
    [SerializeField] protected Transform[] projectileSpawns;
    [SerializeField] protected float chargeTime = 0;
    protected float currentChargeTime;
    protected bool IsCharged;
    public string description;
    public string weaponName;
    #endregion

    public WeaponModel()
    {
        OnLook += LookAt;
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
    public virtual WeaponModel EnableModel()
    {
        return this;
    }
    public virtual WeaponModel DisableModel()
    {
        return this;
    }
    #region Functions
    protected virtual void Awake()
    {
        currentCD = 0;
        canBeUsed = true;
    }
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {
        if (currentCD > 0)
        {
            if (currentCD == useCD)
                onStartCoolDown();
            currentCD -= Time.deltaTime;
        }
        else if (currentCD != 0)
        {
            currentCD = 0;
            onEndCoolDown();
        }
    }
    protected virtual void LookAt(Vector3 point, Vector3 position)
    {
        if (point.x > position.x)
            transform.right = Vector2.Lerp(transform.right, (Vector2)point - (Vector2)transform.position, Time.deltaTime);
        else if (point.x < position.x)
            transform.right = Vector2.Lerp(transform.right, -(Vector2)point + (Vector2)transform.position, Time.deltaTime);
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
        _O.OnUseWeapon();
    }
    protected virtual void EndUse()
    {

    }
    protected virtual void StartCoolDown()
    {
        canBeUsed = false;
    }
    protected virtual void EndCoolDown()
    {
        canBeUsed = true;
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
}
