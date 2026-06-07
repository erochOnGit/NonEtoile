using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    public float distanceFromPlayer = 50;
    public float minimalDistance= 20;
    public List<Texture> textures;
    Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        this.transform.position = new Vector3(Random.value, Random.value, Random.value) * distanceFromPlayer + new Vector3(minimalDistance, minimalDistance, minimalDistance);
        this.transform.LookAt(Camera.main.transform);
        material.SetTexture("BaseColor", textures[Random.Range(0, textures.Count)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

