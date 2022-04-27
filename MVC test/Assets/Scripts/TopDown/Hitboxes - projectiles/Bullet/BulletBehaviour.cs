using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : IHitBoxBehaviour
{
    HitBox myHitBox;
    
    public void Behave()
    {
        myHitBox.transform.position += myHitBox.transform.up * myHitBox.speed * Time.deltaTime;
    }

    public void DieOff()
    {
        
    }

    public void SpawnIn(HitBox H)
    {
        myHitBox = H;
    }
}
