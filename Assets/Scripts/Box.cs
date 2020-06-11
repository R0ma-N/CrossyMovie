using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Animator Animator;
    AnimatorClipInfo[] m_CurrentClipInfo; 

    ParticleSystem boom;

    public bool go;
    public float speed;

    void Start()
    {
        Animator = GetComponent<Animator>();
        m_CurrentClipInfo = Animator.GetCurrentAnimatorClipInfo(0);


        
        boom = GetComponentInChildren<ParticleSystem>();
        boom.Stop();
        go = false;
    }

    void Update()
    {
        if (go)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    public void Boom()
    {
        print("BOOM");
        boom.Play();
    }

    public void OnConveyor()
    {
        go = true;

        //for (int i = 0; i < m_CurrentClipInfo.Length; i++)
        //{
        //    if (m_CurrentClipInfo[i].clip.name == "Box_Armature.006|Salto")
        //    {
        //        Boom();
        //    }
        //}
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
