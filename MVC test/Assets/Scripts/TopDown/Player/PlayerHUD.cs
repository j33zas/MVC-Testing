using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public Image HPFill;
    public Image MPFill;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI MPText;
    public Image currentWPNFill;
    public Image otherWPNFill;

    public void SetBarValue(float max, float curr, string barType)
    {
        Debug.LogError("jeir");
    }
}
