using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	InputAction lookAction;
	InputAction zoomAction;
	public float lookSpeed = 10;
	public float zoomedValue = 20;
	public float unZoomedValue;


	bool isZoomed = false;


	Camera cameraComponent;
	StarBehavior star;
	private Vector2 currentRotation = Vector2.zero;
	void Start()
	{
		lookAction = InputSystem.actions.FindAction("Look");
		zoomAction = InputSystem.actions.FindAction("Zoom");
		cameraComponent = GetComponent<Camera>();
		unZoomedValue = cameraComponent.fieldOfView;


		star = GameObject.FindAnyObjectByType<StarBehavior>();
		
	}

    


    void Update()
    {
		Vector2 lookValue = lookAction.ReadValue<Vector2>();
		lookValue *= Time.deltaTime * lookSpeed; // Adjust sensitivity and frame rate independence

		float zoomValue = zoomAction.ReadValue<float>();
		if (zoomValue > 0)
		{
			cameraComponent.fieldOfView = zoomedValue;

			isZoomed = true;
			lookSpeed = 0.5f;

		}
		else if (zoomValue < 0)
		{
			cameraComponent.fieldOfView = unZoomedValue;
			lookSpeed = 10f;
			isZoomed = false;
		}


		if (isZoomed)
		{
			float dot = Vector3.Dot(cameraComponent.transform.forward, (star.transform.position - cameraComponent.transform.position).normalized);
			if (dot > 0.999f)
			{
				Victory();
			}
		}

        currentRotation.x += lookValue.x;
		currentRotation.y -= lookValue.y;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -80 , 80 );
		Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
	}

	void Victory()
	{
		Debug.Log("Victory!");
		// Implement victory logic here (e.g., display a message, load a new scene, etc.)
	}
}
