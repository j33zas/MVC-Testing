using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    protected SpriteRenderer _SR;
    protected Animator _AN;
    protected AudioSource _AU;
    [SerializeField] ParticleSystem[] particles;
    protected Dictionary<string, ParticleSystem> _partDictionary;
    [SerializeField] AudioClip[] sounds;
    protected Dictionary<string, AudioClip> _soundDictionary;

    protected WeaponView AddParticle(ParticleSystem P)
    {
        _partDictionary.Add(P.name, P);
        return this;
    }

    protected WeaponView AddSound(AudioClip A)
    {
        _soundDictionary.Add(A.name, A);
        return this;
    }

    virtual public void StartChargeView()
    {

    }
    virtual public void EndChargeView()
    {

    }
    virtual public void UseView()
    {

    }
    virtual public void EndUseView()
    {

    }
    virtual public void StartCoolDownView()
    {

    }
    virtual public void EndCoolDownView()
    {

    }
    virtual public void KillEnemyView()
    {

    }
    virtual public void MissView()
    {

    }
    virtual public void PickUpView()
    {

    }
    virtual public void DropView()
    {

    }
    virtual public void EquipView()
    {

    }
}
