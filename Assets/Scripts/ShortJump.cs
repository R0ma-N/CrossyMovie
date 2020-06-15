using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Box>().ShortJump();
    }
}
