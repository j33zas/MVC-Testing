using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPNPickUp : PickUpable
{
    public WeaponModel myWPN;
    [SerializeField] WeaponDescriptionHUD descriptionGUI;
    WeaponDescriptionHUD currDescriptionGUI;
    
    private void Start()
    {
        currDescriptionGUI = Instantiate(descriptionGUI, transform.position, Quaternion.identity);
        currDescriptionGUI.
            SetNameAndDescription(myWPN.weaponName, myWPN.description).
            gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TopDownPlayerModel P = collision.gameObject.GetComponent<TopDownPlayerModel>();
        if (P)
        {
            currDescriptionGUI.gameObject.SetActive(true);
            P.canPickUp = true;
            P.currentPickUpInRange = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TopDownPlayerModel P = collision.gameObject.GetComponent<TopDownPlayerModel>();
        if (P)
        {
            currDescriptionGUI.gameObject.SetActive(false);
            P.canPickUp = false;
            P.currentPickUpInRange = null;
        }
    }

    public override void PickMeUp(TopDownPlayerModel P)
    {
        base.PickMeUp(P);
        var WPNInstance = Instantiate(myWPN, P.transform);
        WPNInstance.transform.position += new Vector3(0, 1.25f, 0);
        WPNInstance.owner = P;
        WeaponLibrary.Library.AddController(WPNInstance);
        var C = WeaponLibrary.Library.GetNewController(myWPN);
        C.SetOwner(P);
        P.OnPickupWPN(C);
        Destroy(gameObject);// cambiar a pool??
        Destroy(currDescriptionGUI.gameObject);// cambiar a pool??
    }
}
