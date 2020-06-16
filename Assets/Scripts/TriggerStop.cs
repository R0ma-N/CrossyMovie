using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStop : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Box>().Stop();
    }
}
