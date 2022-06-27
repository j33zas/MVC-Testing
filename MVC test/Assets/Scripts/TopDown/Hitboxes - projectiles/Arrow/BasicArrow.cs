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
    protected override void Update()
    {
        base.Update();
    }
    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject != Owner)
        {
            Debug.Log("colisione con " + coll.gameObject.name + " y mi dueño es " + Owner);
            _Coll.enabled = false;
            myBehaviour.DieOff();
        }
    }
}