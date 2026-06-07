using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Constellation : MonoBehaviour
{
    private float distanceFromPlayer;
    public float minimalDistance = 20;
    public float animationSpeed = 1;
    int textureID = 0;
    public List<Texture> textures;
    Material material;
    float lastAnim = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Random.InitState(System.DateTime.Now.Second);
        material = GetComponent<Renderer>().material;

        distanceFromPlayer = Random.value * 750.0f;

        Vector3 dir = Random.onUnitSphere;

        this.transform.position = dir * distanceFromPlayer + dir * minimalDistance;
        this.transform.LookAt(Camera.main.transform.position);
        this.transform.Rotate(transform.forward, Random.value);

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
