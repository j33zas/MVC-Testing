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
        _M.OnMove += _V.MoveView;
        _M.OnStop += _V.StopMoveView;
        _M.OnJump += _V.JumpView;
    }

    public Vector2 GetAxis()
    {return Vector2.zero;}

    public void Listener()
    {
        var xinput = Input.GetAxisRaw("Horizontal");
        if (xinput != 0)
            _M.OnMove(xinput);
        else
            _M.OnStop();

        _M.OnJump(Input.GetKey(KeyCode.Space));
    }
}