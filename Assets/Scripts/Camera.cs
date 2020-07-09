using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float offsetX = 7;
    public float offsetY = 7;

    private void Awake()
    {
        //player = GameObject.FindObjectOfType<Box>().transform;
        transform.rotation = Quaternion.Euler(26.2f, 45, 0);
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x - offsetX, transform.position.y, player.position.z - offsetY);
    }
}
