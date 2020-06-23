using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Box>(out Box box))
        {
            box.LeftJump();
        }
    }
}
