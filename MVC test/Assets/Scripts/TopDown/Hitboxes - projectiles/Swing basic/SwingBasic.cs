using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBasic : HitBox
{
    protected override void Awake()
    {
        base.Awake();
        myBehaviour = new SwingBasicBehaviour();
        myBehaviour.SpawnIn(this);
    }
}
