using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandard : HitBox
{
    protected override void Awake()
    {
        base.Awake();
        myBehaviour = new BulletBehaviour();
    }
}
