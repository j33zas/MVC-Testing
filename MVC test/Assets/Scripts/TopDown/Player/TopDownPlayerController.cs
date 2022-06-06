using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : ITopDownController
{
    TopDownPlayerModel _M;
    TopDownPlayerView _V;
    Vector2 lastdir;

    public TopDownPlayerController(TopDownPlayerView V, TopDownPlayerModel M)
    {
        _V = V;
        _M = M;
        _M.OnMove += _V.MoveView;
        _M.OnLook += _V.LookView;
        _M.OnMove += _V.LookView;
        _M.OnRoll += _V.RollView;
        _M.OnEndRoll += _V.EndRollView;
        _M.OnUseWeapon += _V.UseWeaponView;
        _M.OnDodge += _V.DodgeView;
        _M.OnTryPickup += _V.TryPickUpView;
        _M.OnPickupWPN += _V.PickUpView;
        _M.OnSwitchWeapons += _V.SwitchWeaponView;
        _M.OnGetHit += _V.GetHitView;
        _M.OnDie += _V.DieView;
        lastdir = Vector2.zero;
    }

    public Vector2 GetAxis()
    {return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;}

    public Vector2 GetMouseScreenPos()
    {return Camera.main.ScreenToWorldPoint(Input.mousePosition);}

    public void Listener()
    {
        if(GetAxis() != Vector2.zero)
            lastdir = GetAxis();

        _M.OnMove(GetAxis());
        _M.OnLook(GetMouseScreenPos());
        if (Input.GetKeyDown(KeyCode.LeftShift))
            _M.OnRoll(lastdir);
        if (Input.GetKeyDown(KeyCode.E))
            _M.OnTryPickup();
        if (Input.GetKeyDown(KeyCode.Q))
            _M.OnSwitchWeapons();
    }
}
