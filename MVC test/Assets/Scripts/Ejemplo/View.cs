using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View 
{
    Animator _myAnim;
    HUD _hud;

    public View(Animator anim,HUD hud)
    {
        _hud = hud;
        _myAnim = anim;
    }

    public void SetDirectionAnim(Vector2 dir)
    {
        Debug.Log(dir);
    }

    public void UpdateBarLife(float v)
    {
        _hud.SetPercentLife(v);
    }

    public void PlayerDead()
    {
        //Deberia ejecutar animacion de muerte
        Debug.Log("PlayerDead");
    }

    public void RequestParticleToPool()
    {
        Debug.Log("Perdir particulas al pool");
    }
}
