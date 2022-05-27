using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNPickUp : MonoBehaviour
{
    [SerializeField] WeaponModel myWPN;
    [SerializeField] WeaponDescriptionHUD descriptionGUI;
    WeaponDescriptionHUD currDescriptionGUI;
    private void Awake()
    {
        currDescriptionGUI = Instantiate(descriptionGUI, transform.position, Quaternion.identity);
        currDescriptionGUI.SetNameAndDescription(myWPN.weaponName, myWPN.description);
        currDescriptionGUI.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TopDownPlayerModel P = collision.gameObject.GetComponent<TopDownPlayerModel>();
        if(P)
        {
            currDescriptionGUI.gameObject.SetActive(true);
            P.canPickUp = true;
            //P.currentWeaponControllerInRange = myWPN;
            Debug.LogError("Here!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TopDownPlayerModel P = collision.gameObject.GetComponent<TopDownPlayerModel>();
        if (P)
        {
            currDescriptionGUI.gameObject.SetActive(false);
            P.canPickUp = false;
            P.currentWeaponControllerInRange = null;
        }
    }
}
