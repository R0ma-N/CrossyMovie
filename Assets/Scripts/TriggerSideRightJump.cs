using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideRightJump : MonoBehaviour
{
    Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(777);
        other.GetComponent<Box>().RightJump();
    }
}
