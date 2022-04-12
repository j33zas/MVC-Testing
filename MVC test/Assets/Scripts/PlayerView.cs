using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Animator _AN;
    AudioSource _AU;
    SpriteRenderer _SR;
    Rigidbody2D _RB2D;
    Dictionary<string, ParticleSystem> _particlesDic;
    Dictionary<string, AudioClip> _soundsDic;
    [SerializeField]
    ParticleSystem[] Particles;
    [SerializeField]
    AudioClip[] Sounds;
    float acceleration;
    float maxSpeed;
    float VertSpeed;
    float HorSpeed;
    bool isGrounded;
    bool crouched;
    bool canParry;

    private void Start()
    {
        foreach (var part in Particles)
            AddParticle(part.gameObject.name, part);

        foreach (var sound in Sounds)
            AddSound(sound.name, sound);
    }

    private void Update()
    {
        if(_RB2D)
        {
            VertSpeed = _RB2D.velocity.y;
            HorSpeed = _RB2D.velocity.x;
        }
        if(_AN)
        {
            _AN.SetInteger("VerticalSpeed", Mathf.RoundToInt(VertSpeed));
            _AN.SetBool("AirBorne", !isGrounded);
        }
    }

    #region Builder!
    public PlayerView SetAnimator(Animator ANIM)
    {
        _AN = ANIM;
        return this;
    }
    public PlayerView SetAudioSource(AudioSource AUDIO)
    {
        _AU = AUDIO;
        return this;
    }
    public PlayerView SetSpriteRednerer(SpriteRenderer SPRITE)
    {
        _SR = SPRITE;
        return this;
    }
    public PlayerView SetRigidBody(Rigidbody2D RB2D)
    {
        _RB2D = RB2D;
        return this;
    }
    public PlayerView SetGrounded(bool G)
    {
        isGrounded = G;
        return this;
    }
    public PlayerView SetCanParry(bool P)
    {
        canParry = P;
        return this;
    }
    #endregion

    #region Add
    public PlayerView AddParticle(string partName, ParticleSystem particle)
    {
        if (_particlesDic == null)
            _particlesDic = new Dictionary<string, ParticleSystem>();

        if(!_particlesDic.ContainsKey(partName))
            _particlesDic.Add(partName, particle);

        return this;
    }

    public PlayerView AddSound(string audioName, AudioClip audio)
    {
        if (_soundsDic == null)
            _soundsDic = new Dictionary<string, AudioClip>();

        if(!_soundsDic.ContainsKey(audioName))
            _soundsDic.Add(audioName, audio);
        return this;
    }
    #endregion

    #region actions
    public void MoveView(float moveDirection)
    {
        if(isGrounded)
        {
            if(!_particlesDic["Walk"].isEmitting)
                _particlesDic["Walk"].Play();
        }
        else
        {
            if (_particlesDic["Walk"].isEmitting)
                _particlesDic["Walk"].Stop();
        }

        if (moveDirection < 0)
        {
            _SR.flipX = true;
            if(_particlesDic["Walk"].transform.rotation.z != 180)
                _particlesDic["Walk"].transform.Rotate(new Vector3(0, 0, 180));
        }
        else if (moveDirection > 0)
        {
            _SR.flipX = false;
            if(_particlesDic["Walk"].transform.rotation.z != 0)
                _particlesDic["Walk"].transform.Rotate(new Vector3(0, 0, 180));
        }
        _AN.SetFloat("HorizontalSpeed", Mathf.Abs(moveDirection));
    }
    public void StopMoveView()
    {
        _AN.SetFloat("HorizontalSpeed", 0);
        if (_particlesDic["Walk"].isEmitting)
            _particlesDic["Walk"].Stop();
    }
    public void JumpView(bool pressed)
    {
        if(pressed && isGrounded && !_particlesDic["Jump"].isEmitting && !crouched)
            _particlesDic["Jump"].Play();
    }
    public void DoubleJumpView()
    {
        
    }
    public void CrouchView()
    {
        crouched = true;
        _AN.SetBool("Crouched", crouched);
    }
    public void StandView()
    {
        crouched = false;
        _AN.SetBool("Crouched", crouched);
    }
    public void LandView()
    {
        _particlesDic["Land"].Play();
    }
    public void ParryView()
    {
        if(canParry)
            _AN.SetTrigger("Parry");
    }
    public void ShootView()
    {

    }
    #endregion
}
