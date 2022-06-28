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

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        base.OnTriggerEnter2D(coll);
        Destroy(gameObject);
    }
}
