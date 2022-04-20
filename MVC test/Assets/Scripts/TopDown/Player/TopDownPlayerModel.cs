using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TopDownPlayerModel : MonoBehaviour
{
    TopDownPlayerView view;
    TopDownPlayerController controller;
    #region actions
    public Action<Vector2> OnMove;
    public Action<Vector2> OnLook;
    public Action OnStrike;
    public Action OnRoll;
    #endregion
    public TopDownPlayerModel()
    {
        view = GetComponentInChildren<TopDownPlayerView>();
        controller = new TopDownPlayerController(view, this);
    }
}
