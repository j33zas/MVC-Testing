using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitBoxBehaviour 
{
    void SpawnIn(HitBox H);
    void Behave();
    void DieOff();
}
