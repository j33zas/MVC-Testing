using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDMGReceiver 
{
    void GetHit(int DMG, float KnockBack, Vector2 direction, GameObject attacker);
    void DodgeHit();
}
