using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    Box player;
    
    private void Start()
    {
        player = GameObject.FindObjectOfType<Box>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player.Boom();
    }
}
