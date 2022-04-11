using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryProjectile : MonoBehaviour, Iprojectile
{
    Pool<ParryProjectile> _POOL;
    [SerializeField]
    float lifeTime;

    private void Update()
    {
        if (lifeTime > 0)
            lifeTime -= Time.deltaTime;
        else
            _POOL.ReturnObject(this);
    }
    public GameObject DieOff()
    {
        throw new System.NotImplementedException();
    }

    public GameObject GetFired()
    {
        throw new System.NotImplementedException();
    }

    public void GetParried()
    {
        throw new System.NotImplementedException();
    }

    public Iprojectile SetOwner(GameObject O)
    {
        throw new System.NotImplementedException();
    }

    public ParryProjectile SetPool(Pool<ParryProjectile> P)
    {
        _POOL = P;
        return this;
    }
}
