using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    public float speedRotation = 10;
    void Update()
    {
        transform.Rotate(Vector3.forward * speedRotation * Time.deltaTime);
    }
}
