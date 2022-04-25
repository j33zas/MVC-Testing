using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : Controller
{
    public KeyBoardController(Model myOwner,View myView) : base(myOwner,myView)
    {
    }

    public override Vector2 GetAxis()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }


}
