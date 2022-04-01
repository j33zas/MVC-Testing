using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IController
{
    PlayerModel _M;
    PlayerView _V;
    public PlayerController(PlayerModel myOwner, PlayerView myView)
    {
        _M = myOwner;
        _V = myView;
    }

    public Vector2 GetAxis()
    {
        throw new System.NotImplementedException();
    }

    public void Listener()
    {
        throw new System.NotImplementedException();
    }
}
