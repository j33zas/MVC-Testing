using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    #region Stats
    [SerializeField]
    float maxSpeed = 3f;
    [SerializeField]
    float jumpForce = 1f;
    [SerializeField]
    float acceleration = 1f;
    [SerializeField]
    float maxCoyoteTime = .3f;
    float currentCoyoteTime;
    [SerializeField]
    int maxHP = 100;
    [SerializeField]
    Transform LFeet;
    [SerializeField]
    Transform RFeet;
    float currentSpeed = 0;
    int currentHP;
    bool canJump = true;
    bool addingJumpForce = false;
    bool isGrounded = true;
    [SerializeField]
    float groundedRayLength;
    [SerializeField]
    int maxJumpAmount = 2;
    int currentJumpAmount;
    [SerializeField]
    float maxTimePressedJump;
    float currentTimePressedJump;
    [SerializeField]
    float jumpCD;
    float currentJumpCD;
    [SerializeField]
    float maxFallForce;
    [SerializeField]
    float fallForceAcceleration;
    float currentFallForce;

    bool crouched = false;
    #endregion

    #region actions
    public Action<float> OnMove;
    public Action OnStop;
    public Action<int> OnDMG;
    public Action<bool> OnJump;
    public Action OnDoubleJump;
    public Action OnLand;
    public Action OnCrouch;
    public Action OnStand;
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
        //initiate model
        currentHP = maxHP;
        currentJumpAmount = maxJumpAmount;
        currentCoyoteTime = maxFallForce;
        _RB2D = GetComponent<Rigidbody2D>();
        OnMove += MovePL;
        OnStop += StopMoving;
        OnCrouch += Crouch;
        OnStand += OnStand;
        OnDMG += DMGPL;
        OnJump += JumpPL;
        OnDoubleJump += DoubleJump;
        OnParry += ParryPL;
        OnParrySucces += ParrySuccessPL;
        OnShoot += ShootPL;
        OnDie += () =>
        {
            _PLCT = null;
        };
        //initiate view
        _PLVW = GetComponentInChildren<PlayerView>();
        _PLVW.SetAnimator(GetComponentInChildren<Animator>())
             .SetAudioSource(GetComponentInChildren<AudioSource>())
             .SetSpriteRednerer(GetComponentInChildren<SpriteRenderer>())
             .SetRigidBody(_RB2D);
        //initiate controller
        _PLCT = new PlayerController(this, _PLVW);
    }

    private void Update()
    {
        if (_PLCT != null)
            _PLCT.Listener();
        #region Jump Logic
        isGrounded = (Physics2D.Raycast(LFeet.position, Vector2.down, groundedRayLength) || Physics2D.Raycast(RFeet.position, Vector2.down, groundedRayLength));
        _PLVW.SetGrounded(isGrounded);
        _RB2D.gravityScale = currentFallForce;
        if (isGrounded)
        {
            if (currentJumpAmount < maxJumpAmount)
                currentJumpAmount = maxJumpAmount;
            canJump = true;
            currentCoyoteTime = maxCoyoteTime;
            if (currentFallForce != 1)
            {
                OnLand();
                currentFallForce = 1;
            }
        }
        else
        {
            if (currentCoyoteTime > 0)
                currentCoyoteTime -= Time.deltaTime;
            else
                canJump = false;

            if (_RB2D.velocity.y < 0)
                currentFallForce = Mathf.Lerp(currentFallForce, maxFallForce, Time.deltaTime * fallForceAcceleration);
        }
        if (currentJumpAmount <= 0)
            canJump = false;
        #endregion


    }

    #region functions
    void MovePL(float moveDirection)
    {
        if (currentSpeed <= maxSpeed)
            currentSpeed += acceleration * Time.deltaTime;
        _RB2D.AddForce(Vector2.right * moveDirection * currentSpeed * Time.deltaTime, ForceMode2D.Force);
    }
    void StopMoving()
    {
        _RB2D.velocity *= new Vector2(0, 1);
    }

    void JumpPL(bool pressed)
    {
        if (pressed && canJump && !crouched)
        {
            currentTimePressedJump -= Time.deltaTime;
            if (currentTimePressedJump <= 0)
                addingJumpForce = false;
            else
                addingJumpForce = true;

            if (addingJumpForce)
                _RB2D.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Force);
            else
                _RB2D.velocity *= new Vector2(1, 0);

            if (currentJumpCD > 0)
                currentJumpCD -= Time.deltaTime;
        }
        else if(!isGrounded)
        {
            canJump = false;
            currentTimePressedJump = maxTimePressedJump;
        }
    }

    void DoubleJump()
    {
        //if(currentJumpAmount > 0)
        //{
        //    Debug.Log("double JUMP!");
        //    _RB2D.velocity *= new Vector2(1, 0);
        //    _RB2D.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        //    currentJumpAmount--;
        //    currentJumpCD = jumpCD;
        //}
    }

    void DMGPL(int DMG)
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
    void Crouch()
    {
        if(!crouched)
        {
            crouched = true;
        }
    }
    void Stand()
    {
        Debug.Log("UP!");
        if(crouched)
        {
            crouched = false;
        }
    }
    #endregion
}