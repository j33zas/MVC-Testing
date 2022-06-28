using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBasicBehaviour : HitBoxBehaiviour
{
    public override void Behave()
    {
        base.Behave();
        if (_myHitBox.currLifetime > 0)
        {
            _myHitBox.currLifetime -= Time.deltaTime;
            _myHitBox.transform.position += _myHitBox.transform.up * _myHitBox.speed * Time.deltaTime;
        }
        else
        {
            if (canBehave)
                DieOff();
        }
    }
}
