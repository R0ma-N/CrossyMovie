using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    Box box;
    public Animator flatternedCat;

    void Start()
    {
        box = GetComponentInParent<Box>();
        flatternedCat.enabled = false;
    }

    public void Hide()
    {
        box.HideCat();
        flatternedCat.enabled = true;
    }
}
