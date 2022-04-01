using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image barLife;
    

    public void SetPercentLife(float percentHP)
    {
        barLife.fillAmount = percentHP;
    }
}
