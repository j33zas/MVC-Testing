using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArrow : HitBox
{
    
    protected override void Awake()
    {
        base.Awake();
        myBehaviour = new ArrowBehaviour();
        myBehaviour.SpawnIn(this);
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject != owner)
        {
            _Coll.enabled = false;
            myBehaviour.DieOff();
        }
    }
}
