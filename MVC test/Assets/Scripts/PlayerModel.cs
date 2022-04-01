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
    public Action<float> OnWalk;
    public Action<int> OnDMG;
    public Action OnJump;
    public Action OnLand;
    public Action OnParry;
    public Action OnParrySucces;
    public Action OnShoot;
    #endregion

    private void Start()
    {
        currentHP = maxHP;

    }
}
