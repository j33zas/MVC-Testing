using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model : MonoBehaviour
{
    public float speed;
    float life;
    float maxLife;
    public Action<Vector2> OnMove;
    public Action<float> OnTakeDamage;
    public Action OnDead;
    Controller _myController;

    private void Awake()
    {
        life = maxLife = 100;
        View tempView = new View(GetComponent<Animator>(),FindObjectOfType<HUD>());
        _myController = new KeyBoardController(this,tempView);
        OnMove += MovePlayer;
        OnDead += () => _myController = null;
        //OnDead += () => EventManager.Instance.FireEvent("DeadPlayer");
        //GameInstance.Instance.AddToEvent("Dead", Dead);
        //GameInstance.Instance.RemoveToEvent("Dead", Dead);
        //GameInstance.Instance.TriggerEvent("Dead");
        //GameInstance.Instance.RemoveToUpdate(this);
        //GameInstance.Instance.AddToUpdate(this);
    }

    void Update()
    {
        if(_myController != null)
            _myController.Listener();
    }

    void MovePlayer(Vector2 dir)
    {
        transform.position += new Vector3(dir.x, 0, dir.y) * speed * Time.deltaTime;
    }


    public void TakeDamage()//Lo hago publico para el controller porque esta cabeza
    {
        life -= 10;
        OnTakeDamage(life / maxLife);
        if (life <= 0)
            OnDead();
    }
}
