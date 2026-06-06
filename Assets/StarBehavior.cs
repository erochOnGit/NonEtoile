using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarBehavior : MonoBehaviour
{
    public float distanceFromPlayer = 50;
    public float minimalDistance= 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        this.transform.position = new Vector3(Random.value, Random.value, Random.value) * distanceFromPlayer + new Vector3(minimalDistance, minimalDistance, minimalDistance);
        this.transform.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

