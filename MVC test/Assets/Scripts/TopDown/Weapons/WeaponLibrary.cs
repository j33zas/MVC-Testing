using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLibrary : MonoBehaviour
{
    Dictionary<WeaponModel, WeaponController> MtoC;
    static WeaponLibrary me;
    public static WeaponLibrary Library
    {
        get
        {
            return me;
        }
    }
    private void Awake()
    {
        me = this;
        //MtoC.Add(WPNSwordModel A, WPNSwordController)
    }

    public WeaponController GetControllerFromModel(WeaponModel M)
    {
        if (MtoC.ContainsKey(M))
        {
            return MtoC[M];
        }
        else
        {
            Debug.LogError("Model to controller dictionary does not have reference to that object");
            return null;
        }
    }
}
