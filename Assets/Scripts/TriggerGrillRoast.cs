using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrillRoast : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Box>().Roast();
    }
}
