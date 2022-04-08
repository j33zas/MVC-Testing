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
    #endregion

    #region actions
    public Action<float> OnMove;
    public Action OnStop;
    public Action<int> OnDMG;
    public Action<bool> OnJump;
    public Action OnDoubleJump;
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
        //initiate model
        currentHP = maxHP;
        currentJumpAmount = maxJumpAmount;
        _RB2D = GetComponent<Rigidbody2D>();
        OnMove += MovePL;
        OnStop += StopMoving;
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
        if (isGrounded)
        {
            if (currentJumpAmount < maxJumpAmount)
                currentJumpAmount = maxJumpAmount;
            canJump = true;
            currentCoyoteTime = maxCoyoteTime;
        }
        else
        {
            if (currentCoyoteTime > 0)
            {
                currentCoyoteTime -= Time.deltaTime;
            }
            else
            {
                canJump = false;
            }
        }
        if (currentJumpAmount <= 0)
            canJump = false;
        #endregion
    }

    #region functions
    void MovePL(float moveDirection)
    {
        if(currentSpeed <= maxSpeed)
            currentSpeed += acceleration * Time.deltaTime;
        _RB2D.AddForce(Vector2.right * moveDirection * currentSpeed * Time.deltaTime,ForceMode2D.Force);
    }
    void StopMoving()
    {
        _RB2D.velocity *= new Vector2(0, 1);
    }

    void JumpPL(bool pressed)
    {
        if (pressed)
        {
            //if(canJump && currentJumpAmount > 0 && !isGrounded && currentJumpCD <= 0)
            //{
            //    OnDoubleJump();
            //    return;
            //}
            currentTimePressedJump -= Time.deltaTime;
            if (currentTimePressedJump <= 0)
            {
                currentTimePressedJump = 0;
                addingJumpForce = false;
            }
            else
            {
                addingJumpForce = true;
            }
            if (canJump && addingJumpForce && currentJumpAmount > 0)
            {
                _RB2D.velocity *= new Vector2(1, 0);
                _RB2D.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Force);
            }
        }
        else
        {
            currentTimePressedJump = maxTimePressedJump;
        }
        if(currentJumpCD > 0)
            currentJumpCD -= Time.deltaTime;
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
    #endregion
}