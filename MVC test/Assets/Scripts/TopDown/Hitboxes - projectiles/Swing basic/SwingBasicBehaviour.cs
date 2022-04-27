using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBasicBehaviour : IHitBoxBehaviour
{
    HitBox myHitBox;
    public void Behave()
    {
        myHitBox.transform.position += myHitBox.transform.right * myHitBox.speed * Time.deltaTime;
    }

    public void DieOff()
    {

    }

    public void SpawnIn(HitBox H)
    {
        myHitBox = H;
    }
}
