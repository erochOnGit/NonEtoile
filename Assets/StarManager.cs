using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StarManager : MonoBehaviour
{
	public List<GameObject> starsAndConstellations;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(var go in starsAndConstellations)
        {
            Constellation constellation = go.GetComponent<Constellation>();
            GameObject instance = GameObject.Instantiate(go);
		}
	}

}

