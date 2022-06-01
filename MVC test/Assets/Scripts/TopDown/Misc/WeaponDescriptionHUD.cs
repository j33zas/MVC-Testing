using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponDescriptionHUD : MonoBehaviour
{
    public TextMeshProUGUI descriptionTextMesh;
    public TextMeshProUGUI nameTextMesh;

    public WeaponDescriptionHUD SetNameAndDescription(string name, string description)
    {
        descriptionTextMesh.text = description;
        nameTextMesh.text = name;
        return this;
    }
}
