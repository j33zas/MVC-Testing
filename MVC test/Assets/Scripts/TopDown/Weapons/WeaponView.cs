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
    [SerializeField] protected ChargeWeaponHUD chargeWPNCanvas;
    protected ChargeWeaponHUD currentChargeWPNCanvas;
    public ChargeWeaponHUD HUD
    {
        get
        {
            return currentChargeWPNCanvas;
        }
    }
    bool isCharged;
    public bool charged
    {
        get
        { return isCharged; }
        set
        { isCharged = value;}
    }

    protected virtual void Start()
    {
        _SR = GetComponent<SpriteRenderer>();
        _AN = GetComponent<Animator>();
        _AU = GetComponent<AudioSource>();
        foreach (var S in sounds)
            AddSound(S);
        foreach (var P in particles)
            AddParticle(P);
    }

    protected void PlaySound(string name)
    {
        _AU.PlayOneShot(_soundDictionary[name]);
    }

    protected void PlayParticle(string name)
    {
        _partDictionary[name].Play();
    }

    protected WeaponView AddParticle(ParticleSystem P)
    {
        if (_partDictionary == null)
            _partDictionary = new Dictionary<string, ParticleSystem>();
        _partDictionary.Add(P.name, P);
        return this;
    }

    protected WeaponView AddSound(AudioClip A)
    {
        if (_soundDictionary == null)
            _soundDictionary = new Dictionary<string, AudioClip>();
        _soundDictionary.Add(A.name, A);
        return this;
    }
    virtual public void LookAtView(Vector3 point, Vector3 positionRef)
    {
        if (point.y < positionRef.y)
            _SR.sortingLayerName = "AbovePlayer";
        else if (point.y > positionRef.y)
            _SR.sortingLayerName = "BehindPlayer";
    }           
    
    virtual public void StartChargeView()
    {

    }
    virtual public void StopChargeView()
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
    virtual public void HitView()
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
