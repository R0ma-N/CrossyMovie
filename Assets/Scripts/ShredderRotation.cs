using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderRotation : MonoBehaviour
{
    public float speedRotation = 100;
    void Update()
    {
        transform.Rotate(Vector3.left * speedRotation * Time.deltaTime);
    }
}
