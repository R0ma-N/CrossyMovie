using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSaw : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(555);
        other.gameObject.GetComponent<Box>().JumpSaw();
    }
}
