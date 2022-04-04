using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Animator _AN;
    AudioSource _AU;
    Dictionary<string, ParticleSystem> _particles;
    Dictionary<string, AudioClip> _sounds;

    public PlayerView(Animator anim, AudioSource audio)
    {
        _AN = anim;
        _AU = audio;
    }

    public void AddParticle(string partName, ParticleSystem particle)
    {
        _particles.Add(partName, particle);
    }

    public void AddSound(string audioName, AudioClip audio)
    {
        _sounds.Add(audioName, audio);
    }

    public void MoveView(float MoveSpeed)
    {
        _AN.SetFloat("CurrentSpeed", MoveSpeed);
    }
}
