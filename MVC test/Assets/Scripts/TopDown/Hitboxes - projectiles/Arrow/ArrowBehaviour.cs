using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : HitBoxBehaiviour
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
    public override void DieOff()
    {
        base.DieOff();
        canBehave = false;
        _myHitBox.speed = 0;
        MonoBehaviour.Destroy(_myHitBox.GetComponent<HitBox>());
        MonoBehaviour.Destroy(_myHitBox.GetComponent<Rigidbody2D>());
        MonoBehaviour.Destroy(_myHitBox.GetComponent<BoxCollider2D>());
        MonoBehaviour.Destroy(_myHitBox.GetComponentInChildren<TrailRenderer>());
    }
}