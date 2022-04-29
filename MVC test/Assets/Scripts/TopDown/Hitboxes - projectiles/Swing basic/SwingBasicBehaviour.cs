using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBasicBehaviour : HitBoxBehaiviour
{
    public override void Behave()
    {
        _myHitBox.transform.position += _myHitBox.transform.right * _myHitBox.speed * Time.deltaTime;
    }
}