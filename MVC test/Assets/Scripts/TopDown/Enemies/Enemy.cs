using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDMGReceiver
{
    [SerializeField] int maxHP;
    int currHP;
    EnemyBehaviour myBehaviour;
    [SerializeField] bool canBeKncockedBack;
    [SerializeField] float knockBackResist;
    #region unity stuff
    protected Rigidbody2D _RB;
    protected SpriteRenderer _SR;
    protected Animator _AN;
    #endregion
    public virtual void DodgeHit()
    {
        
    }

    public virtual void GetHit(int DMG, float KnockBack, Vector2 direction, GameObject attacker)
    {
        currHP -= DMG;
        if (!canBeKncockedBack)
        {
            _RB.AddForce((direction * KnockBack) / knockBackResist, ForceMode2D.Impulse);
        }
        if(currHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }

    protected virtual void Awake()
    {
        _AN = GetComponent<Animator>();
        _SR = GetComponent<SpriteRenderer>();
        _RB = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        
    }
    
    protected virtual void Update()
    {
        
    }
}
