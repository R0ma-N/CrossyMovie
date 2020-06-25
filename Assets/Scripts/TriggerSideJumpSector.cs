using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideJumpSector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.InSideJumpSector(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.InSideJumpSector(false);
        }
    }
}
