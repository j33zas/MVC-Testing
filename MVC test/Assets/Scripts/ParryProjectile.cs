using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryProjectile : MonoBehaviour, Iprojectile
{
    Pool<ParryProjectile> _POOL;
    [SerializeField]
    float maxLifeTime;
    float currentLifeTime;

    GameObject _owner;

    private void Update()
    {
        if (currentLifeTime > 0)
            currentLifeTime -= Time.deltaTime;
        else if(_POOL != null)
            _POOL.ReturnObject(this);
    }
    public GameObject DieOff()
    {
        gameObject.SetActive(false);
        currentLifeTime = maxLifeTime;
        return gameObject;
    }

    public GameObject GetFired()
    {
        gameObject.SetActive(true);
        return gameObject;
    }

    public void GetParried()
    {
        
    }

    public Iprojectile SetOwner(GameObject O)
    {
        _owner = O;
        return this;
    }

    public ParryProjectile SetPool(Pool<ParryProjectile> P)
    {
        _POOL = P;
        return this;
    }
}
