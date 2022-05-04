using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TopDownPlayerModel : MonoBehaviour,IDMGReceiver
{
    #region Components
    TopDownPlayerView view;
    TopDownPlayerController controller;
    Rigidbody2D _RB2D;
    GameObject hands;
    WeaponController currentWeapon;
    List<WeaponController> weaponInventory = new List<WeaponController>();
    #endregion

    #region Stats
    [Header("Health")]
    [SerializeField] int maxHP;
    int currentHP;
    bool DMGInvulnerable;
    bool knockBackInvulnerable;
    [Header("Movement")]
    [SerializeField] float maxSpeed;
    float currentSpeed;
    [SerializeField] float acceleration;
    float currentAcceleration;
    [SerializeField] float deAcceleration;
    float currentDeAcceleration;
    [Header("Roll")]
    [SerializeField] float rollForce;
    [SerializeField] float rollInvulnerableTime;
    [SerializeField] float rollCD;
    float currentRollCD;
    bool canRoll;
    bool isRolling;
    [Header("camera")]
    [SerializeField] Camera cam;
    [SerializeField] float cameraMaxDistance;
    [SerializeField] float cameraLerpSpeed;
    Vector2 mouseOnWorld = Vector2.zero;

    #endregion

    #region actions
    public Action<Vector2> OnMove;
    public Action<Vector2> OnLook;
    public Action<Vector2> OnRoll;
    public Action OnEndRoll;
    public Action OnUseWeapon;
    public Action OnDodge;
    public Action OnPickUpWeapon;
    public Action<int,float, Vector2, GameObject> OnGetHit;
    public Action<GameObject> OnDie;
    #endregion

    private void Awake()
    {

    }

    public void Start()
    {
        view = GetComponentInChildren<TopDownPlayerView>();
        controller = new TopDownPlayerController(view, this);
        _RB2D = GetComponent<Rigidbody2D>();
        OnMove += Move;
        OnLook += Look;
        OnRoll += Roll;
        OnEndRoll += EndRoll;
        OnUseWeapon += UseWeapon;
        OnDodge += DodgeHit;
        OnPickUpWeapon += PickUpWeapon;
        OnGetHit += GetHit;
        OnDie += Die;

        isRolling = false;
        canRoll = true;
        currentRollCD = 0;
        currentHP = maxHP;
        currentAcceleration = acceleration;
        currentDeAcceleration = deAcceleration;

        currentWeapon = new WPNSwordController(GetComponentInChildren<WPNSwordModel>(), GetComponentInChildren<WPNSwordView>(), this);
        cam = Camera.main;
    }
    private void Update()
    {
        if (controller != null)
        {
            controller.Listener();
        }

        if (currentWeapon != default)
        {
            currentWeapon.Listener();
        }

        if (!canRoll)
        {
            currentRollCD += Time.deltaTime;
            if (currentRollCD >= rollCD)
            {
                canRoll = true;
                currentRollCD = 0;
            }
        }
        if(cam != null)
            CameraPositioning(cam.ScreenToWorldPoint(Input.mousePosition));
    }

    #region functions
    void Move(Vector2 dir)
    {
        if (isRolling) return;
        if (dir != Vector2.zero)
        {
            if (currentSpeed < maxSpeed)
                currentSpeed += Time.deltaTime * currentAcceleration;
            else
                currentSpeed = maxSpeed;
            _RB2D.AddForce(dir * currentSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= Time.deltaTime * currentDeAcceleration;
            else
                currentSpeed = 0;
            _RB2D.velocity = dir * currentSpeed;
        }
        if (_RB2D.velocity.magnitude > maxSpeed)
            _RB2D.velocity = dir * currentSpeed;
    }

    void Look(Vector2 point)
    {
        if (isRolling) return;
        if (point.x < transform.position.x)
        {
            if (transform.localScale != new Vector3(-1, 1, 1))
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            if (transform.localScale != new Vector3(1, 1, 1))
                transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void CameraPositioning(Vector2 P)
    {
        Vector2 middlePoint = (P - (Vector2)transform.position)/ 2 / cameraMaxDistance;
        cam.transform.position = Vector2.Lerp(cam.transform.position, middlePoint + (Vector2)transform.position, Time.deltaTime * cameraLerpSpeed);
        cam.transform.position += new Vector3(0, 0, -1);
    }
    void Roll(Vector2 dir)
    {
        if (!canRoll) return;

        canRoll = false;
        isRolling = true;
        DMGInvulnerable = true;
        knockBackInvulnerable = true;

        _RB2D.velocity = Vector2.zero;
        _RB2D.AddForce(dir * rollForce, ForceMode2D.Impulse);
        if (dir.x < 0)
        {
            if (transform.localScale != new Vector3(-1, 1, 1))
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            if (transform.localScale != new Vector3(1, 1, 1))
                transform.localScale = new Vector3(1, 1, 1);
        }
        StartCoroutine(EndRollinvulnerability(rollInvulnerableTime));
    }

    void EndRoll()
    {
        DMGInvulnerable = false;
        knockBackInvulnerable = false;
        isRolling = false;
        _RB2D.velocity = Vector2.zero;
    }

    void UseWeapon()
    {

    }

    void PickUpWeapon()
    {

    }

    void SwitchWeapons()
    {
            
    }

    void Die(GameObject killer)
    {

    }

    #endregion


    IEnumerator EndRollinvulnerability(float time)
    {
        yield return new WaitForSeconds(time);
        OnEndRoll();
    }

    public void GetHit(int DMG, float knockBack, Vector2 direction, GameObject attacker)
    {
        if (!DMGInvulnerable)
            currentHP -= DMG;
        else OnDodge();

        if (!knockBackInvulnerable)
            _RB2D.AddForce(direction * knockBack, ForceMode2D.Impulse);
    }

    public void DodgeHit()
    {
        Debug.Log("OSOM!");
    }
}
