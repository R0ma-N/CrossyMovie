using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortalTeleport : MonoBehaviour
{
    public Transform target;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.transform.position = target.position;
        }
    }
}
