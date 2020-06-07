using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Animator Animator;
    //Rigidbody rigidbody;
    Collider Collider;

    public float speed;
    public bool InJumpSetor;
    public bool escapeDeath = false;
    
    void Start()
    {
        Animator = GetComponent<Animator>();
        ///rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (!InJumpSetor)
        //    {
        //        Animator.SetTrigger("Jump");
        //    }
        //    else
        //    {
        //        Animator.SetTrigger("BigJump");
        //        escapeDeath = true;
        //    }
        //}
    }

    public void fall()
    {
        Animator.enabled = true;
        Animator.SetTrigger("Fall");
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void GoConveyor()
    {
        Animator.SetTrigger("OnConveyor");
    }

    public void Saw()
    {

            Animator.SetTrigger("Saw");

    }

    public void JumpSaw()
    {
        Animator.SetTrigger("JumpSaw");
        Animator.SetBool("CanGo", true);
    }

    public void SideJump()
    {
        Animator.SetTrigger("SideJump");
    }
    public void RigedBodySwitcher()
    {

    }

    public void Shredder()
    {
        Animator.SetTrigger("Shredder");
    }

}
