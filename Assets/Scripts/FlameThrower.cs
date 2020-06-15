using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    ParticleSystem fire;
    void Start()
    {
        fire = GetComponent<ParticleSystem>();
        fire.Stop();
    }

    public void Play()
    {
        fire.Play();
    }

    public void Stop()
    {
        fire.Stop();
    }

}
