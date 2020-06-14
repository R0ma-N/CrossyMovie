using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    MeshRenderer MeshRenderer;
    private float scrollSpeed;
    private float coeff;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        coeff = GameObject.FindObjectOfType<Box>().CoeffOfMovingSpeed;
        scrollSpeed = -0.17f;
        //coeff = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed * coeff;
        MeshRenderer.materials[2].mainTextureOffset = new Vector2(offset, 0);
    }
}
