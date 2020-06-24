using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideRightJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(777);
        other.GetComponent<Box>().RightJump();
    }
}
