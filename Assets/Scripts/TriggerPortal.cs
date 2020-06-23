using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortal : MonoBehaviour
{
    BoxCollider transportTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.Portal("enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.Portal("out");
        }
    }
}
