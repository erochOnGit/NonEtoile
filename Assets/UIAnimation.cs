using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{

    public List<Texture> sprites;
    public float animationSpeed = 1;
    int textureID = 0;
    float lastAnim = 0;

    RawImage image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAnim > animationSpeed)
        {
            textureID = (textureID + 1) % sprites.Count;
            image.texture = sprites[textureID];
            lastAnim = Time.time;
        }

    }
}
