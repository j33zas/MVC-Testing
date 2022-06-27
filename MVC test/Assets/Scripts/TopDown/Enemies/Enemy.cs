using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDMGReceiver
{
    [SerializeField] int maxHP;
    int currHP;
    EnemyBehaviour myBehaviour;
    [SerializeField] bool canBeKncockedBack;
    #region unity stuff
    Rigidbody2D _RB;
    SpriteRenderer _SR;
    Animator _AN;
    #endregion
    public void DodgeHit()
    {
        
    }

    public void GetHit(int DMG, float KnockBack, Vector2 direction, GameObject attacker)
    {
        currHP -= DMG;
        if (!canBeKncockedBack)
        {
            _RB.AddForce(direction * KnockBack, ForceMode2D.Impulse);
        }
        if(currHP <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {

    }

    protected void Awake()
    {
        
    }

    protected void Start()
    {
        
    }
    
    protected void Update()
    {
        
    }
}
