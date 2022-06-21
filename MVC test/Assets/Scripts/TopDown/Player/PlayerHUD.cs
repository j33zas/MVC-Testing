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
    private void Awake()
    {
        HPFill.gameObject.SetActive(false);
        MPFill.gameObject.SetActive(false);
        HPText.gameObject.SetActive(false);
        MPText.gameObject.SetActive(false);
        currentWPNFill.gameObject.SetActive(false);
        otherWPNFill.gameObject.SetActive(false);
    }

    #region setters
    public PlayerHUD SetHPTXT(int max)
    {
        if (!HPText.gameObject.activeInHierarchy)
            HPText.gameObject.SetActive(true);
        HPText.text = max + "/" + max;
        return this;
    }
    public PlayerHUD SetMPTXT(int max)
    {
        if (!MPText.gameObject.activeInHierarchy)
            MPText.gameObject.SetActive(true);
        MPText.text = max + "/" + max;
        return this;
    }
    public PlayerHUD SetHPBar()
    {
        if (!HPFill.gameObject.activeInHierarchy)
            HPFill.gameObject.SetActive(true);
        HPFill.fillAmount = 1;
        return this;
    }
    public PlayerHUD SetMPBar()
    {
        if (!MPFill.gameObject.activeInHierarchy)
            MPFill.gameObject.SetActive(true);
        MPFill.fillAmount = 1;
        return this;
    }
    public PlayerHUD SetCurrentWPN()
    {
        return this;
    }
    #endregion

    public void SetBarValue(float max, float curr, string barType)
    {
        
    }
}
