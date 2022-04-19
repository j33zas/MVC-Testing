using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float lifetime;
    public int dmg;
    public float speed;
    public float knockBack;
    public Vector2 knockBackDirection;
    GameObject _O;
    public GameObject owner
    {
        get
        {
            return _O;
        }
        set
        {
            _O = value;
        }
    }
    protected IHitBoxBehaviour myBehaviour;
    IDMGReceiver hitEntity;
    Collider2D _Coll;
    virtual protected void Awake()
    {
        
    }
    virtual protected void Start()
    {
        if (myBehaviour != null)
            myBehaviour.SpawnIn(this);
        else
            Debug.LogError("Hitbox " + name + " has no IHitBoxBehavour assigned and couldn´t start properly");
    }

    virtual protected void Update()
    {
        if(myBehaviour != null)
            myBehaviour.Behave();
    }
    virtual protected void OnDisable()
    {
        if(myBehaviour != null)
            myBehaviour.DieOff();
    }
    virtual protected void OnTriggerEnter2D(Collider2D coll)
    {
        var dmgreceiver = coll.gameObject.GetComponent<IDMGReceiver>();
        if(dmgreceiver != null)
            dmgreceiver.GetHit(dmg, knockBack, knockBackDirection, owner);
        gameObject.SetActive(false);
    }
}
