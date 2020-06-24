using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Box : MonoBehaviour
{
    Animator Animator;
    SkinnedMeshRenderer meshRenderer;
    public AnimationCurve Up, Forward;
    ParticleSystem boom;
    AudioSource sound;
    [SerializeField] AudioClip[] audioClips;
    public bool go;
    private Vector3 startPosition;
    public bool canJump;
    public bool Jump;
    float timeElapsed;

    public float CoeffOfMovingSpeed;
    private float speed;

    void Start()
    {
        Animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        sound = GetComponent<AudioSource>();
        boom = GetComponentInChildren<ParticleSystem>();
        if(boom) boom.Stop();
        Jump = false;
        speed = 2;
    }

    void Update()
    {
        if (go)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * CoeffOfMovingSpeed);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canJump)
        {
            JumpSaw();
        }

        if (Jump)
        {
            timeElapsed += Time.deltaTime;
            transform.position = new Vector3(
                startPosition.x + Forward.Evaluate(timeElapsed) * CoeffOfMovingSpeed, 
                startPosition.y + Up.Evaluate(timeElapsed), 
                transform.position.z);
        }

    }

    public void OutConveyor()
    {
        go = false;
        canJump = false;
        timeElapsed = 0;
        startPosition = transform.position;
        Jump = true;
    }
    public void OnConveyor()
    {
        go = true;
        canJump = true;
        Jump = false;
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

    public void Stop()
    {
        go = false;
    }

    public void Portal(string state)
    {
        if (state == "enter")
        {
            meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
        }
        else if (state == "out")
        {
            meshRenderer.shadowCastingMode = ShadowCastingMode.On;
        }
    }

}
