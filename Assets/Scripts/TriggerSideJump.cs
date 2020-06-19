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
        if(other.TryGetComponent<Box>(out Box box))
        {
            box.LeftJump();
        }
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
