using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Animator Count;
    float coinsCount;
    Text[] texts;
    
    void Start()
    {
        Count = GetComponent<Animator>();
        texts = GetComponentsInChildren<Text>();
        coinsCount = 0;
        texts[0].text = texts[1].text = "x " + 0;
    }

    public void Shake()
    {
        Count.SetTrigger("GotCoin");
        coinsCount++;
        texts[0].text = texts[1].text = "x " + coinsCount;
    }
}
