using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLibrary : MonoBehaviour
{
    Dictionary<WeaponClass, WeaponController> WPNTypeToController = new Dictionary<WeaponClass, WeaponController>();
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
    }

    public WeaponController GetNewController(WeaponModel M)
    {
        if (WPNTypeToController.ContainsKey(M.myWPNType))
        {
            return WPNTypeToController[M.myWPNType];
        }
        else
        {
            Debug.LogError("Model to controller dictionary does not have reference to that object");
            return default;
        }
    }
    public void AddController(WeaponModel M)
    {
        if (WPNTypeToController.ContainsKey(M.myWPNType))
            return;
        WeaponController C;
        switch (M.myWPNType)
        {
            case WeaponClass.Sword:
                C = new WPNSwordController(M, M.GetComponentInChildren<WeaponView>());
                WPNTypeToController.Add(M.myWPNType, C);
                break;
            case WeaponClass.Hammer:
                C = new WPNHammerController(M, M.GetComponentInChildren<WeaponView>());
                WPNTypeToController.Add(M.myWPNType, C);
                break;
            case WeaponClass.CrossBow:
                //C = new WPNCrossbowController(M, M.GetComponentInChildren<WeaponView>(), null);
                //WPNTypeToController.Add(M.myWPNType, C);
                break;
            case WeaponClass.Bow:
                C = new WPNBowController(M, M.GetComponentInChildren<WeaponView>());
                WPNTypeToController.Add(M.myWPNType, C);
                break;
            default:
                Debug.Log("Weapon Type is not contemplated in the WaponLibrary or is No Class");
                break;
        }
    }
}

public enum WeaponClass 
{
    NoClass,
    Sword,
    Hammer,
    CrossBow,
    Bow
}