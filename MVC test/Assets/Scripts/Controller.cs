using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : IController
{
    Model _owner;
    private Model myOwner;

    public Controller(Model myOwner, View myView)
    {
        _owner = myOwner;
        _owner.OnMove += myView.SetDirectionAnim;
        _owner.OnTakeDamage += myView.UpdateBarLife;
        _owner.OnDead += myView.RequestParticleToPool;
        _owner.OnDead += myView.PlayerDead;
    }

    protected Controller(Model myOwner)
    {
        this.myOwner = myOwner;
    }

    public abstract Vector2 GetAxis();

    public void Listener()
    {
        _owner.OnMove(GetAxis());

        if (Input.GetKeyDown(KeyCode.T))
            _owner.TakeDamage();
    }
}
