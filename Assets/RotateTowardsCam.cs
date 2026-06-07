using UnityEngine;

public class RotateTowardsCam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		transform.LookAt((transform.position - Camera.main.transform.position));
        //this.transform.LookAt(Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

	}
}
