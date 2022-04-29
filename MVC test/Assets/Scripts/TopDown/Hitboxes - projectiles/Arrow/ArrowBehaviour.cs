using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : HitBoxBehaiviour
{
    public override void Behave()
    {
        base.Behave();
        _myHitBox.transform.position += _myHitBox.transform.up * _myHitBox.speed * Time.deltaTime;
    }
}
