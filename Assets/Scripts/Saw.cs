using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    ParticleSystem cutting;

    private void Start()
    {
        cutting = GetComponentInChildren<ParticleSystem>();
        cutting.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Box>().Saw();
        cutting.Play();
    }

}
