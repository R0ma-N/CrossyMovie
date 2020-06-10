using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Animator Animator;
    Collider Collider;

    public bool go;
    public float speed;

    
    void Start()
    {
        Animator = GetComponent<Animator>();
        Collider = GetComponentInChildren<Collider>();
        go = false;
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
        if (go)
        {
            //transform.position += Vector3.right * Time.deltaTime * speed;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    public void OnConveyor()
    {
        print(666666);
        go = true;
    }

    public void OutConveyor()
    {
        print(999999);
        go = false;
    }

    public void GoConveyor()
    {
        Animator.SetTrigger("OnConveyor");
    }

    public void Saw()
    {
        Animator.SetTrigger("Saw");
        go = false;
    }

    public void JumpSaw()
    {
        Animator.SetTrigger("JumpSaw");
    }

    public void LeftJump()
    {
        Animator.SetTrigger("JumpToLeft");
        go = false;
    }

    public void Shredder()
    {
        Animator.SetTrigger("Shredder");
        go = false;
    }

}
