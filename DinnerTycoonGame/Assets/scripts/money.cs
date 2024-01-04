using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public int moneyCounter=0;

    public TextMesh moneyText;

    public AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = moneyCounter.ToString();
        
    }
}
