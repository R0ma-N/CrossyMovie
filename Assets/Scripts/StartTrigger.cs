using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    GameObject player;
    
    private void Start()
    {
        player = GameObject.FindObjectOfType<Box>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Camera.main.transform.SetParent(player.transform);
    }
}
