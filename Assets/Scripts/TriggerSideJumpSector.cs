using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideJumpSector : MonoBehaviour
{
    private Transform BoxTarget;

    void Start()
    {
        BoxTarget = GetComponentsInChildren<Transform>()[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.InSideJumpSector(true);
            box.TargetForSideJump = BoxTarget;
            print("Inside Jump Sector");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.InSideJumpSector(false);
            print("Out of Jump Sector");
        }
    }
}
