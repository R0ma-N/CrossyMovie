﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    public float offsetX = 7;
    public float offsetY = 7;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Box>().transform;
    }

    private void Update()
    {
        transform.position = new Vector3(player.position.x - offsetX, transform.position.y, player.position.z - offsetY);
    }
}
