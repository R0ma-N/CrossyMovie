using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    MeshRenderer MeshRenderer;
    public float scrollSpeed = 0.5f;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        MeshRenderer.materials[2].mainTextureOffset = new Vector2(offset, 0);
    }
}
