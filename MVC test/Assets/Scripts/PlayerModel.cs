using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    #region Stats
    [SerializeField]
    float speed = 1f;
    [SerializeField]
    float jumpHeight = 1f;
    [SerializeField]
    float acceleration = 1f;
    [SerializeField]
    float coyoteTime = .3f;
    [SerializeField]
    int maxHP = 100;
    int currentHP;
    #endregion

    #region actions
    public Action<float> OnMove;
    public Action<int> OnDMG;
    public Action OnJump;
    public Action OnLand;
    public Action OnParry;
    public Action OnParrySucces;
    public Action OnShoot;
    public Action OnDie;
    #endregion

    #region Unity components
    Rigidbody2D _RB2D;
    PlayerController _PLCT;
    PlayerView _PLVW;
    #endregion

    private void Start()
    {
        currentHP = maxHP;
        _PLVW = GetComponentInChildren<PlayerView>();
        _PLCT = new PlayerController(this, _PLVW);
        OnMove += MovePL;
        OnDMG += DMGPL;
        OnJump += JumpPL;
        OnParry += ParryPL;
        OnParrySucces += ParrySuccessPL;
        OnShoot += ShootPL;
        OnDie += () =>
        {
            _PLCT = null;

        };
    }

    private void Update()
    {
        if (_PLCT != null)
            _PLCT.Listener();

    }

    #region functions
    void MovePL(float speed)
    {
        Debug.Log(speed);
    }
    void DMGPL(int DMG)
    {

    }
    void JumpPL()
    {

    }
    void ParryPL()
    {

    }
    void ParrySuccessPL()
    {

    }
    void ShootPL()
    {

    }
    #endregion
}