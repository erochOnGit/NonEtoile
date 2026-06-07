using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarBehavior : MonoBehaviour
{
    private float distanceFromPlayer;
    public float minimalDistance= 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distanceFromPlayer = Random.value * 100.0f;

		this.transform.position = Random.onUnitSphere * distanceFromPlayer + new Vector3(minimalDistance, minimalDistance, minimalDistance);
        this.transform.LookAt(Camera.main.transform);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

