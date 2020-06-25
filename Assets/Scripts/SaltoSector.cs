using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoSector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.InSaltoSector(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.InSaltoSector(false);
        }
    }
}
