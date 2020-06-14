using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Box player;
    private UI UI;

    private void Awake()
    {
        UI = GameObject.FindObjectOfType<UI>();
        player = GameObject.FindObjectOfType<Box>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player.Coin();
        UI.Shake();
        Destroy(gameObject);
    }
}
