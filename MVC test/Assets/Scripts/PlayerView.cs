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
    bool grounded;
    bool crouched;

    private void Start()
    {
        foreach (var part in Particles)
            AddParticle(part.gameObject.name, part);

        foreach (var sound in Sounds)
            AddSound(sound.name, sound);
    }

    private void Update()
    {
        VertSpeed = _RB2D.velocity.y;
        HorSpeed = _RB2D.velocity.x;
        _AN.SetInteger("VerticalSpeed", Mathf.RoundToInt(VertSpeed));
        _AN.SetBool("AirBorne", !grounded);
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
        grounded = G;
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
        if (moveDirection < 0)
            _SR.flipX = true;
        else if (moveDirection > 0)
            _SR.flipX = false;
        _AN.SetFloat("HorizontalSpeed", Mathf.Abs(moveDirection));
    }
    public void StopMoveView()
    {
        _AN.SetFloat("HorizontalSpeed", 0);
    }
    public void JumpView(bool pressed)
    {
        if(pressed && grounded && !_particlesDic["Jump"].isEmitting && !crouched)
            _particlesDic["Jump"].Play();
    }
    public void DoubleJumpView()
    {
        //
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
    #endregion
}
