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
    }

    public Vector2 GetAxis()
    {
        var xinput = Input.GetAxisRaw("Horizontal");
        var yinput = Input.GetAxisRaw("Vertical");
        return new Vector2(xinput, yinput);
    }

    public void Listener()
    {
        var xinput = Input.GetAxisRaw("Horizontal");
        if(xinput !=0)
            _M.OnMove(xinput);
        if (Input.GetKeyDown(KeyCode.Space))
            _M.OnJump();
    }
}