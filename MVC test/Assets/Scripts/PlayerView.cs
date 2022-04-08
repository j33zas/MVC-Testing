using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Animator _AN;
    AudioSource _AU;
    SpriteRenderer _SR;
    Rigidbody2D _RB2D;
    Dictionary<string, ParticleSystem> _particles;
    Dictionary<string, AudioClip> _sounds;

    float acceleration;
    float maxSpeed;
    float VertSpeed;
    float HorSpeed;
    bool grounded;

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
        _particles.Add(partName, particle);
        return this;
    }

    public PlayerView AddSound(string audioName, AudioClip audio)
    {
        _sounds.Add(audioName, audio);
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

    }
    public void DoubleJumpView()
    {

    }
    #endregion
}
