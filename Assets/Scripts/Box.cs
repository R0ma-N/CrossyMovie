﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Box : MonoBehaviour
{
    public Material BoxDissolve;
    public AnimationCurve SaltoUp, SaltoForward;
    public Animator CatAnimator;
    private Transform _catTransform;
    Animator Animator;
    MeshRenderer[] meshRenderers;
    public RuntimeAnimatorController AutoPlay, UsualPlay;
    SkinnedMeshRenderer[] meshRenderer;
    ParticleSystem boom;
    AudioSource sound;
    [SerializeField] AudioClip[] audioClips = null;

    public bool AutomaticPlay;
    bool _roast;
    public float _roastTime;

    //For moving
    public bool go;
    private Vector3 previousPosition, VectorNormDirection;
    private MovementDirection movementDirection;

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
    public Vector3 LerpOffsetX;
    public float LerpTimeSalto = 1.15f;

    //For Side Jump
    public float LerpTimeSideJump;
    public Transform TargetForSideJump;
    private Quaternion startRotation;
    private bool _catRightJump = false;
    private bool _catLeftJump;

    [SerializeField] private bool _inSaltoSector;
    private bool _doSalto;
    [SerializeField] private bool _inLeftSideJumpSector;
    private bool _doSideJump;

    void Start()
    {
        Animator = GetComponent<Animator>();
        _catTransform = CatAnimator.gameObject.transform;
        meshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
        sound = GetComponent<AudioSource>();
        boom = GetComponentInChildren<ParticleSystem>();
        if(boom) boom.Stop();
        Jump = false;
        speed = 2;

        if (AutomaticPlay)
        {
            Animator.runtimeAnimatorController = AutoPlay;
        }
        else
        {
            Animator.runtimeAnimatorController = UsualPlay;
        }
    }

    void Update()
    {
        
        if (AutomaticPlay)
        {
            if (go)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * CoeffOfMovingSpeed);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Salto();
            }
        }
        else
        {
            if (previousPosition != transform.position)
            {
                VectorNormDirection = (previousPosition - transform.position).normalized;

                if (VectorNormDirection.x == -1 & VectorNormDirection.y == 0 & VectorNormDirection.z == 0)
                {
                    movementDirection = MovementDirection.Forward;
                }
                else if (VectorNormDirection.x == 1 & VectorNormDirection.z == 0)
                {
                    movementDirection = MovementDirection.Back;
                }
                else if (VectorNormDirection.x <= 0 & VectorNormDirection.y <= 0 & VectorNormDirection.z == -1)
                {
                    movementDirection = MovementDirection.Left;
                }
                else if (VectorNormDirection.x <= 0 & VectorNormDirection.z == 1)
                {
                    movementDirection = MovementDirection.Right;
                }
            }

            previousPosition = transform.position;

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

                    if (_inLeftSideJumpSector)
                    {
                        if (transform.position.z < TargetForSideJump.position.z && movementDirection == MovementDirection.Forward ||
                            transform.position.x > TargetForSideJump.position.x && movementDirection == MovementDirection.Left)
                        {
                            LeftJump();
                            _doSideJump = true;
                        }
                        else
                        {
                            RightJump();
                            _doSideJump = true;
                        }
                    }
                }
            }

            if (_doSalto & Jump)
            {
                _timer += Time.deltaTime;

                if (_timer > LerpTimeSalto)
                {
                    _timer = LerpTimeSalto;
                }

                float LerpRatio = _timer / LerpTimeSalto;

                Vector3 positionOffsetY = SaltoUp.Evaluate(LerpRatio) * LerpOffsetY;
                Vector3 positionOffsetX = SaltoForward.Evaluate(LerpRatio) * LerpOffsetX;

                switch (movementDirection)
                {
                    case MovementDirection.Forward:
                        transform.position = Vector3.Lerp(
                            startPosition,
                            new Vector3(startPosition.x + 8, startPosition.y, startPosition.z),
                            LerpRatio) + positionOffsetX + positionOffsetY;
                        print("forward jump");
                        break;
                    case MovementDirection.Back:
                        transform.position = Vector3.Lerp(
                        startPosition,
                        new Vector3(startPosition.x - 8, startPosition.y, startPosition.z),
                        LerpRatio) - positionOffsetX + positionOffsetY;
                        print("back jump");
                        break;
                    case MovementDirection.Right:
                        transform.position = Vector3.Lerp(
                        startPosition,
                        new Vector3(startPosition.x, startPosition.y, startPosition.z - 8),
                        LerpRatio) + positionOffsetY + positionOffsetX;
                        print("right jump");
                        break;
                    case MovementDirection.Left:
                        transform.position = Vector3.Lerp(
                        startPosition,
                        new Vector3(startPosition.x, startPosition.y, startPosition.z + 8),
                        LerpRatio) + positionOffsetY + positionOffsetX;
                        print("left jump");
                        break;
                }
            }

            if (_doSideJump & Jump)
            {
                _timer += Time.deltaTime;

                if (_timer > LerpTimeSideJump)
                {
                    _timer = LerpTimeSideJump;
                }

                float LerpRatio = _timer / LerpTimeSideJump;

                transform.position = Vector3.Lerp(startPosition, TargetForSideJump.position, LerpRatio);
                transform.rotation = Quaternion.Lerp(startRotation, TargetForSideJump.rotation, LerpRatio);
            }
        }

        if (_catRightJump)
        {
            print("right");
            _catTransform.rotation = new Quaternion(0, 360, 0, 0);
        }

        if (_roast)
        {
            _timer += Time.deltaTime;

            if (_timer > _roastTime)
            {
                _timer = _roastTime;
            }

            float LerpRatio = _timer / _roastTime;

            meshRenderer[1].material.SetFloat("Vector1_BurnTime", LerpRatio);
            meshRenderer[0].material.SetFloat("Vector1_BurnTime", LerpRatio);
            meshRenderer[2].material.color = Color.Lerp(Color.white, Color.black, LerpRatio);
        }

    }

    public void OutConveyor()
    {
        go = false;
        canJump = false;
        _timer = 0;
        startPosition = transform.position;
        startRotation = transform.rotation;
        Jump = true;
        print(VectorNormDirection);
        print(movementDirection);
    }

    public void OnConveyor()
    {
        print("OnConveyor");
        go = true;
        canJump = true;
        Jump = false;
        _doSideJump = false;
        _doSalto = false;
    }

    public void HideCat()
    {
        print("HideCat");
        _catTransform.localScale = new Vector3(0, 0, 0);
    }

    public void UnHideCat()
    {
        _catTransform.localScale = new Vector3(1, 1, 1);
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
        if (boom)
        {
            print("BOOM");
            sound.clip = audioClips[0];
            sound.Play();
            boom.Play();
        }
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
        CatAnimator.SetTrigger("Saw");
        go = false;
        //sound.clip = audioClips[3];
        //sound.Play();
    }

    public void Salto()
    {
        Animator.SetTrigger("JumpSaw");
        CatAnimator.SetTrigger("JumpSaw");
        sound.clip = audioClips[2];
        sound.PlayDelayed(0.1f);
    }

    public void LeftJump()
    {
        Animator.SetTrigger("JumpToLeft");
        CatAnimator.SetTrigger("JumpToLeft");
        //sound.clip = audioClips[4];
        //sound.PlayDelayed(0.1f);
    }

    public void RightJump()
    {
        Animator.SetTrigger("JumpToRight");
        CatAnimator.SetTrigger("JumpToRight");
        _catRightJump = true;

        //_catRightJump = true;
        //sound.clip = audioClips[4];
        //sound.PlayDelayed(0.1f);
    }

    public void Shredder()
    {
        Animator.SetTrigger("Shredder");
        CatAnimator.SetTrigger("Shredder");
        //sound.clip = audioClips[6];
        //sound.Play();
        go = false;
    }

    public void Stop()
    {
        go = false;
    }

    public void Roast()
    {
        go = false;
        _timer = 0;
        Animator.SetTrigger("Roast");
        CatAnimator.SetTrigger("Roast");
        meshRenderer[0].material = meshRenderer[1].material = BoxDissolve;

        _roast = true;
    }

    public void InSaltoSector(bool state)
    {
        _inSaltoSector = state;
    }

    public void InSideJumpSector(bool state)
    {
        _inLeftSideJumpSector = state;
    }

    public void Portal(string state)
    {
        //if (state == "enter")
        //{
        //    meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
        //}
        //else if (state == "out")
        //{
        //    meshRenderer.shadowCastingMode = ShadowCastingMode.On;
        //}
    }

}

public enum MovementDirection
{
    Forward,
    Back,
    Left,
    Right
}
