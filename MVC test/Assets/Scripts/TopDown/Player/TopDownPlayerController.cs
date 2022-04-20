using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour, ITopDownController
{
    TopDownPlayerModel _model;
    TopDownPlayerView _view;
    public TopDownPlayerController(TopDownPlayerView V, TopDownPlayerModel M)
    {
        _view = V;
        _model = M;
        _model.OnLook += _view.LookView;
        _model.OnMove += _view.LookView;
        _model.OnStrike += _view.StrikeView;
        _model.OnRoll += _view.RollView;
    }

    public Vector2 GetAxis()
    {return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;}

    public Vector2 GetMouseScreenPos()
    {return Camera.main.ScreenToWorldPoint(Input.mousePosition);}

    public void Listener()
    {
        _model.OnLook(GetMouseScreenPos());

        if(GetAxis() != Vector2.zero)
            _model.OnMove(GetAxis());

        if (Input.GetMouseButton(1))
            _model.OnRoll();
        if (Input.GetMouseButton(0))
            _model.OnStrike();
    }
}
