using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    private float distanceFromPlayer;
    public float minimalDistance= 20;
    public List<Texture> textures;
    Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Random.InitState(System.DateTime.Now.Second);
        material = GetComponent<Renderer>().material;
        material.mainTexture = textures[Random.Range(0, textures.Count)];
        distanceFromPlayer = Random.value * 10.0f;
		this.transform.position = Random.onUnitSphere * distanceFromPlayer + new Vector3(minimalDistance, minimalDistance, minimalDistance);
        this.transform.LookAt(Camera.main.transform);
        
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

