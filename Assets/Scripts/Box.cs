using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Animator Animator;
    AudioSource sound;
    [SerializeField] bool go;
    [SerializeField] AudioClip[] audioClips;

    ParticleSystem boom;


    public float CoeffOfMovingSpeed;
    private float speed;

    void Start()
    {
        Animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        boom = GetComponentInChildren<ParticleSystem>();
        boom.Stop();
        //CoeffOfMovingSpeed = 1;
        speed = 2;
        //go = false;
    }

    void Update()
    {
        if (go)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * CoeffOfMovingSpeed);
        }
    }

    internal void Falling()
    {
        Animator.SetTrigger("JumpOfFaith");
        go = false;
    }

    public void ShortJump()
    {
        Animator.SetTrigger("Short Jump");
        sound.clip = audioClips[4];
        sound.PlayDelayed(0.1f);
    }

    public void Boom()
    {
        print("BOOM");
        sound.clip = audioClips[0];
        sound.Play();
        boom.Play();
    }

    public void Starting()
    {
        sound.clip = audioClips[1];
        sound.Play();
    }

    public void OnConveyor()
    {
        go = true;
    }

    public void OutConveyor()
    {
        go = false;
    }

    public void GoConveyor()
    {
        Animator.SetTrigger("OnConveyor");
    }

    public void Saw()
    {
        Animator.SetTrigger("Saw");
        sound.clip = audioClips[3];
        sound.Play();
        go = false;
    }

    public void JumpSaw()
    {
        Animator.SetTrigger("JumpSaw");
        sound.clip = audioClips[2];
        sound.PlayDelayed(0.1f);
    }

    public void LeftJump()
    {
        Animator.SetTrigger("JumpToLeft");
        sound.clip = audioClips[4];
        sound.PlayDelayed(0.1f);
    }
    internal void RightJump()
    {
        Animator.SetTrigger("JumpToRight");
        sound.clip = audioClips[4];
        sound.PlayDelayed(0.1f);
    }

    public void Shredder()
    {
        Animator.SetTrigger("Shredder");
        sound.clip = audioClips[6];
        sound.Play();
        go = false;
    }

}
