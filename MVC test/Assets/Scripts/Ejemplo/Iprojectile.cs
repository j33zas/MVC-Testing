using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iprojectile
{
    void GetParried();
    GameObject GetFired();
    GameObject DieOff();
    Iprojectile SetOwner(GameObject O);
}
