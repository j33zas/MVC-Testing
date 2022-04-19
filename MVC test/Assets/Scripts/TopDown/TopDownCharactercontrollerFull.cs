using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharactercontrollerFull : MonoBehaviour, IDMGReceiver
{
    Animator _AN;
    Rigidbody2D _RB2D;
    SpriteRenderer _SR;

    #region Stats
    [Header("STATS")]

    #region Health
    [SerializeField] int maxHP;
    int currentHP;
    bool DMGInvulnerable;
    bool knockBackInvulnerable;
    
    #endregion

    #region Movement Stats
    [Header("movement")]
    [SerializeField] float maxSpeed;
    float currentSpeed;
    [SerializeField] float acceleration;
    float currentAcceleration;
    [SerializeField] float deAcceleration;
    float currentDeAcceleration;
    [SerializeField] Vector2 direction;
    Vector2 lastDir;
    float Xinput;
    float Yinput;
    [SerializeField] GameObject hands;
    #endregion

    #region roll Stats
    [Header("roll")]
    [SerializeField] float rollForce;
    [SerializeField] float rollInvulnerableTime;
    [SerializeField] float rollNoInputTime;
    [SerializeField] float rollCD;
    float currentRollCD;
    bool canRoll;
    bool isRolling;
    #endregion

    #region Camera
    [Header("camera")]
    [SerializeField] Camera cam;
    [SerializeField] float cameraMaxDistance;
    Vector2 mouseOnWorld = Vector2.zero;

    #endregion

    #endregion

    #region keybinds
    [Header("KEYBINDS")]
    [SerializeField] KeyCode rollKey;
    [SerializeField] KeyCode interactKey;
    [SerializeField] [Range(0, 2)] int abilityMouseBTN;
    [SerializeField] [Range(0, 2)] int attackMouseBTN;
    #endregion

    #region Particles
    [Header("PARTICLES")]
    [SerializeField] ParticleSystem walkParticle;
    [SerializeField] ParticleSystem rollParticle;
    [SerializeField] ParticleSystem endRollParticle;
    #endregion
    void Start()
    {
        _RB2D = GetComponent<Rigidbody2D>();
        _AN = GetComponentInChildren<Animator>();
        _SR = GetComponentInChildren<SpriteRenderer>();
        currentSpeed = 0;
        currentAcceleration = acceleration;
        currentDeAcceleration = deAcceleration;
        currentRollCD = 0;
        currentHP = maxHP;
    }
    
    void Update()
    {
        if(!canRoll)
        {
            if(currentRollCD == 0)
                currentRollCD = rollCD;
            if(currentRollCD > 0)
            {
                currentRollCD -= Time.deltaTime;
                if(currentRollCD <= 0)
                {
                    canRoll = true;
                    currentRollCD = 0;
                }
            }
        }

        #region input
        Xinput = Input.GetAxisRaw("Horizontal");
        Yinput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(Xinput, Yinput).normalized;
        mouseOnWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        #endregion

        #region functions
        Move(direction);
        HandsLooking(mouseOnWorld);
        CameraPositioning(mouseOnWorld);
        if (Input.GetKeyDown(rollKey))
            Roll(direction);
        #endregion

        #region animations
        _AN.SetFloat("Speed", currentSpeed);
        #endregion
    }

    void Move(Vector2 direction)
    {
        if (isRolling) return;
        if (direction != Vector2.zero)
        {
            if (currentSpeed < maxSpeed)
                currentSpeed += Time.deltaTime * currentAcceleration;
            else
                currentSpeed = maxSpeed;
            lastDir = direction;
            _RB2D.AddForce(direction * currentSpeed * Time.deltaTime, ForceMode2D.Impulse);
            if(!walkParticle.isEmitting)
                walkParticle.Play();

        }
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= Time.deltaTime * currentDeAcceleration;
            else
                currentSpeed = 0;
            _RB2D.velocity = lastDir * currentSpeed;
            if(walkParticle.isEmitting)
                walkParticle.Stop();
        }
        if (_RB2D.velocity.magnitude > maxSpeed)
            _RB2D.velocity = direction * currentSpeed;

    }

    void Roll(Vector2 direction)
    {
        if (!canRoll) return;
        
        canRoll = false;
        isRolling = true;
        DMGInvulnerable = true;
        knockBackInvulnerable = true;

        _AN.SetTrigger("Roll");
        rollParticle.Play();

        if (direction == Vector2.zero)
            direction = lastDir;

        _RB2D.velocity = Vector2.zero;
        _RB2D.AddForce(direction * rollForce * Time.deltaTime, ForceMode2D.Impulse);

        if(direction.x < 0)
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
        StartCoroutine(EndRollImpulse(rollNoInputTime));
        
    }

    IEnumerator EndRollinvulnerability(float time)
    {
        yield return new WaitForSeconds(time);
        DMGInvulnerable = false;
        knockBackInvulnerable = false;
    }

    IEnumerator EndRollImpulse(float time)
    {
        yield return new WaitForSeconds(time);
        isRolling = false;
        _RB2D.velocity = Vector2.zero;
        endRollParticle.Play();
        rollParticle.Stop();
        _SR.color = Color.white;
    }

    void HandsLooking(Vector2 screenPoint)
    {
        if (isRolling) return;
        hands.transform.right = (Vector2)transform.position - screenPoint;
        if(screenPoint.x < transform.position.x)
        {
            if(transform.localScale != new Vector3(-1, 1, 1))
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            if (transform.localScale != new Vector3(1, 1, 1))
                transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void CameraPositioning(Vector2 mousePos)
    {
        Vector2 middlePoint = ((Vector2)transform.position + mousePos) / cameraMaxDistance;
        cam.transform.position = new Vector3(middlePoint.x,middlePoint.y, cam.transform.position.z);

    }

    public void GetHit(int DMG, float KnockBack, Vector2 direction, GameObject attacker)
    {
        if (!DMGInvulnerable)
            currentHP -= DMG;
        else DodgeHit();

        if(!knockBackInvulnerable)
            _RB2D.AddForce(direction * KnockBack, ForceMode2D.Impulse);

        Debug.Log(currentHP);
    }

    public void DodgeHit()
    {
        Debug.Log("EPICO!");
        _SR.color = Color.cyan;
    }
}
