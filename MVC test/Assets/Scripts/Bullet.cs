using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, Iprojectile
{
    [SerializeField]
    float lifeTime;
    float currentLifeTime;
    [SerializeField]
    float mySpeed;
    protected GameObject owner;
    //BulletBehaviour BBH;

    Collider2D _COLL;
    SpriteRenderer _SR;
    Pool<Bullet> _POOL;

    private void Update()
    {
        if (currentLifeTime > 0)
            currentLifeTime -= Time.deltaTime;
        else
            _POOL.ReturnObject(this);

        transform.position += Vector3.right * mySpeed * Time.deltaTime;
        //BBH.Behave();
    }

    public GameObject GetFired()
    {
        currentLifeTime = lifeTime;
        gameObject.SetActive(true);
        return gameObject;
    }

    public void GetParried()
    {

    }

    public GameObject DieOff()
    {
        gameObject.SetActive(false);
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
