using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] HitBox projectile;
    [SerializeField] Transform shootDirection;
    [SerializeField] Transform shootPosition;
    [SerializeField] float fireRate;
    float _currFireRate;
    GameObject target;

    private void Start()
    {
        _currFireRate = fireRate;
        target = FindObjectOfType<TopDownCharactercontrollerFull>().gameObject;
    }
    private void Update()
    {
        shootDirection.up = (Vector2)target.transform.position - (Vector2)transform.position;
        if (_currFireRate > 0)
        {
            _currFireRate -= Time.deltaTime;
        }
        else
        {
            _currFireRate = fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        var B = Instantiate(projectile, shootPosition.position, shootDirection.rotation);
        B.Owner = gameObject;
    }
}
