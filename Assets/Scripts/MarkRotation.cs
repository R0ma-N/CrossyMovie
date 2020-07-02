using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkRotation : MonoBehaviour
{
    [SerializeField] private float speedRotation;
    
    void Update()
    {
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
    }
}
