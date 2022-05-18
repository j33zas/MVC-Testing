using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float lifetime;
    int _myDMG;
    public int dmg
    {
        get
        {
            return _myDMG;
        }
        set
        {
            _myDMG = value;
        }
    }
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
    protected Collider2D _Coll;
    virtual protected void Awake()
    {
        _Coll = GetComponent<Collider2D>();
    }
    virtual protected void Start()
    {
        if (myBehaviour != null)
            myBehaviour.SpawnIn(this);
        else
            Debug.LogError("Hitbox " + name + " has no HitBox Behavour assigned and couldn�t start properly");
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
        if(coll.gameObject != _O || coll.GetType() != GetType())
        {
            var dmgreceiver = coll.gameObject.GetComponent<IDMGReceiver>();
            if(dmgreceiver != null)
            {
                dmgreceiver.GetHit(dmg, knockBack, knockBackDirection, _O);
                Debug.Log("damage");
            }
        }
    }
}
