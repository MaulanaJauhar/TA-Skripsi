using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeksWaktu : MonoBehaviour
{
    TextMeshProUGUI TextTimer;
    float DataWaktu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextTimer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
