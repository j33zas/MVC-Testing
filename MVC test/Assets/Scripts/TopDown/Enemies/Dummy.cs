using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Enemy
{
    override public void GetHit(int DMG, float KnockBack, Vector2 direction, GameObject attacker)
    {
        base.GetHit(DMG, KnockBack, direction, attacker);
        _AN.Play("Hurt");
        TimeController.controller.HitStop(.1f);
        //TimeManager.HitStop();
    }
}
