using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITopDownController
{
    void Listener();
    Vector2 GetAxis();
    Vector2  GetMouseScreenPos();
}
