using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Constellation : MonoBehaviour
{
    public float animationSpeed = 1;
    int textureID = 0;
    public List<Texture> textures;
    Material material;
    float lastAnim = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        this.transform.LookAt(Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAnim > animationSpeed) { 
            textureID = (textureID + 1) % textures.Count;
            material.mainTexture = textures[textureID];
            lastAnim = Time.time;
        }
    }
}
