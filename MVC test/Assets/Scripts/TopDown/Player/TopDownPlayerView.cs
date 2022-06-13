using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerView : MonoBehaviour
{
    Animator _AN;
    SpriteRenderer _SR;
    AudioSource _AU;
    TrailRenderer _TR;
    [SerializeField] ParticleSystem[] particles;
    protected Dictionary<string, ParticleSystem> _partDictionary;
    [SerializeField] AudioClip[] sounds;
    protected Dictionary<string, AudioClip> _soundDictionary;
    [SerializeField] PlayerHUD PLHUD;
    PlayerHUD currPLHUD;
    [Header("camera")]
    [SerializeField] float cameraMaxDistance;
    [SerializeField] float cameraLerpSpeed;

    private void Awake()
    {
        _SR = GetComponent<SpriteRenderer>();
        _AN = GetComponent<Animator>();
        _TR = GetComponentInChildren<TrailRenderer>();
        _TR.gameObject.SetActive(false);
        currPLHUD = Instantiate(PLHUD);
        foreach (var S in sounds)
            AddSound(S);
        foreach (var P in particles)
            AddParticle(P);
    }

    #region sounds & particles
    protected void PlaySound(string name)
    {
        _AU.PlayOneShot(_soundDictionary[name]);
    }

    protected ParticleSystem GetParticle(string name)
    {
        return _partDictionary[name];
    }

    protected TopDownPlayerView AddParticle(ParticleSystem P)
    {
        if (_partDictionary == null)
            _partDictionary = new Dictionary<string, ParticleSystem>();
        _partDictionary.Add(P.name, P);
        return this;
    }

    protected TopDownPlayerView AddSound(AudioClip A)
    {
        if (_soundDictionary == null)
            _soundDictionary = new Dictionary<string, AudioClip>();
        _soundDictionary.Add(A.name, A);
        return this;
    }
    #endregion

    public void MoveView(Vector2 dir)
    {
        _AN.SetFloat("Speed", dir.magnitude);

        if (dir != Vector2.zero)
        {
            if(!GetParticle("Walk").isEmitting)
                GetParticle("Walk").Play();
        }
        else
        {
            if(GetParticle("Walk").isEmitting)
                GetParticle("Walk").Stop();
        }
    }

    public void LookView(Vector2 v2)
    {
        //CameraController.controller.CameraPositioning(v2, cameraMaxDistance, cameraLerpSpeed, gameObject);
    }

    public void RollView(Vector2 dir)
    {
        if(!_AN.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            _AN.SetTrigger("Roll");
            GetParticle("Rolling").Play();
        }
        if (!_TR.gameObject.activeInHierarchy)
            _TR.gameObject.SetActive(true);
    }

    public void EndRollView()
    {
        GetParticle("RollEnd").Play();
        GetParticle("Rolling").Stop();
        if (_TR.gameObject.activeInHierarchy)
            _TR.gameObject.SetActive(false);
    }

    public void UseWeaponView()
    {

    }

    public void SwitchWeaponView()
    {

    }

    public void DodgeView()
    {
        
    }

    public void TryPickUpView()
    {

    }

    public void PickUpView(WeaponController item)
    {
        
    }

    public void GetHitView(int DMG, float knockBack, Vector2 direction, GameObject hitter)
    {

    }

    public void DieView(GameObject killer)
    {

    }
}
