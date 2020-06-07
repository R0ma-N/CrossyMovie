using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(777);
        other.GetComponent<Box>().SideJump();
    }
}
