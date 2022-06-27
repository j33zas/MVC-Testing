using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxBehaiviour : IHitBoxBehaviour
{
    protected HitBox _myHitBox;
    public bool canBehave = true;
    public virtual void Behave()
    {
        if (_myHitBox == null && canBehave)
            Debug.LogError("No Hitbox assigned for " + this + ", assign a hitbox after instancing/asking the pool for the object");
    }

    public virtual void DieOff()
    {
        canBehave = false;
    }

    public virtual void SpawnIn(HitBox H)
    {
        _myHitBox = H;
        canBehave = true;
        //Debug.LogError("Hitboxes are using Destroy instead of returning to the Object Pool");
    }
}
