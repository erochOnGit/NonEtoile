using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomText : MonoBehaviour
{
    TextMeshPro text;

    public List<string> texts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = texts[Random.Range(0,texts.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
