using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSideJump : MonoBehaviour
{
    public bool active;
    Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(777);
        other.GetComponent<Box>().SideJump();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            active = true;
            collider.enabled = true;
        }
    }
}
