using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UI UI;
    AudioSource sound;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        UI = GameObject.FindObjectOfType<UI>();
        sound = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.Shake();
        meshRenderer.enabled = false;
        sound.Play();
        Destroy(gameObject,1f);
    }
}
