using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Iprojectile
{
    [SerializeField]
    float maxTimeAlive;
    float currentTimeAlive;
    [SerializeField]
    float speed;
    protected GameObject owner;

    Collider2D _COLL;
    SpriteRenderer _SR;
    Pool<Bullet> _POOL;

    private void Update()
    {
        if (currentTimeAlive > 0)
            currentTimeAlive -= Time.deltaTime;
        else
            _POOL.ReturnObject(this);
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public GameObject GetFired()
    {
        currentTimeAlive = maxTimeAlive;
        throw new System.NotImplementedException();
    }

    public void GetParried()
    {
        throw new System.NotImplementedException();
    }

    public GameObject DieOff()
    {
        return gameObject;
    }

    public Iprojectile SetOwner(GameObject O)
    {
        owner = O;
        return this;
    }

    public Bullet SetPool(Pool<Bullet> P)
    {
        _POOL = P;
        return this;
    }
}
