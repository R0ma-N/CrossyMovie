using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Box : MonoBehaviour
{
    public AnimationCurve SaltoUp, SaltoForward, SideJumpUp, SideJumpForward;
    Animator Animator;
    SkinnedMeshRenderer meshRenderer;
    ParticleSystem boom;
    AudioSource sound;
    [SerializeField] AudioClip[] audioClips;

    public bool go;

    //For game speed control
    public float CoeffOfMovingSpeed;
    private float speed;

    //For Jumps
    private Vector3 startPosition;
    public float _timer;
    public bool canJump;
    public bool Jump;

    //For Salto
    public Vector3 LerpOffsetY;
    public float LerpTimeSalto = 1.15f;

    //For Side Jump
    public Vector3 LerpOffsetX;
    public float LerpTimeSideJump;
    public Transform TargetForSideJump;
    public Transform target;

    

    private bool _inSaltoSector;
    private bool _inLeftSideJumpSector;
    private bool _doSalto;
    private bool _doLeftSideJump;

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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canJump)
            {
                if (_inSaltoSector)
                {
                    Salto();
                    _doSalto = true;
                }
                else if (_inLeftSideJumpSector)
                {
                    LeftJump();
                    _doLeftSideJump = true;
                }
            }
        }

        if (Jump && _doSalto)
        {
            _timer += Time.deltaTime;

            if (_timer > LerpTimeSalto)
            {
                _timer = LerpTimeSalto;
            }

            float LerpRatio = _timer / LerpTimeSalto;
            Vector3 positionOffsetY = SaltoUp.Evaluate(LerpRatio) * LerpOffsetY;
            Vector3 positionOffsetX = SaltoForward.Evaluate(LerpRatio) * LerpOffsetX;

            transform.position = Vector3.Lerp(
                startPosition,
                new Vector3(startPosition.x + 8, startPosition.y, startPosition.z),
                LerpRatio) + positionOffsetX + positionOffsetY;

            _doSalto = Jump;
        }

        if (Jump && _doLeftSideJump)
        {
            //TODO изменить плюс оффсета для других положений. помимо positionOffsetX

            _timer += Time.deltaTime;

            if (_timer > LerpTimeSideJump)
            {
                _timer = LerpTimeSideJump;
            }

            float LerpRatio = _timer / LerpTimeSideJump;
            Vector3 positionOffsetX = SideJumpForward.Evaluate(LerpRatio) * LerpOffsetX;

            transform.position = Vector3.Slerp(
                startPosition,
                TargetForSideJump.position,
                LerpRatio) + positionOffsetX;

            transform.rotation = Quaternion.Slerp(Quaternion.identity, TargetForSideJump.rotation, 1);

            if (TargetForSideJump)
            {
                RaycastHit hit;
                Ray Ray = new Ray(transform.position, TargetForSideJump.position);
                if (Physics.Raycast(Ray, out hit)) print("Hit target at " + hit.distance + " meters");
            }

            //_doLeftSideJump = Jump;
        }

    }

    public void OutConveyor()
    {
        go = false;
        canJump = false;
        _timer = 0;
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

    public void Salto()
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

        _inLeftSideJumpSector = true;
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

    public void InSaltoSector(bool state)
    {
        _inSaltoSector = state;
    }

    public void InSideJumpSector(bool state)
    {
        _inLeftSideJumpSector = state;
        /////////////
        if (state)
        {
        LeftJump();
        _doLeftSideJump = true;

        }
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
