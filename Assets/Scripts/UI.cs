using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Animator Count;
    [SerializeField] float coinsCount;
    Text text;
    
    void Start()
    {
        Count = GetComponent<Animator>();
        text = GetComponent<Text>();
        //coinsCount = 0;
        text.text = "x " + coinsCount;
    }

    public void Shake()
    {
        Count.SetTrigger("GotCoin");
        coinsCount++;
        text.text = text.text = "x " + coinsCount;
    }
}
