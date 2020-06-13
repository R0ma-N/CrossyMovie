using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    MeshRenderer MeshRenderer;
    private float scrollSpeed = - 0.25f;
    private float coeff;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        coeff = GameObject.FindObjectOfType<Box>().Coeff;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed * coeff;
        MeshRenderer.materials[2].mainTextureOffset = new Vector2(offset, 0);
    }
}
