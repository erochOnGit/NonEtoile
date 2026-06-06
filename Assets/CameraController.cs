using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	InputAction lookAction;
	InputAction zoomAction;
	public float lookSpeed;
	public float zoomedValue = 20;
	public float unZoomedValue;
	Camera camera; 

	private Vector2 currentRotation = Vector2.zero;
	void Start()
	{
		lookAction = InputSystem.actions.FindAction("Look");
		zoomAction = InputSystem.actions.FindAction("Zoom");
		camera = GetComponent<Camera>();
		unZoomedValue = camera.fieldOfView;
    }

    void Update()
    {
		Vector2 lookValue = lookAction.ReadValue<Vector2>();
		lookValue *= Time.deltaTime * lookSpeed; // Adjust sensitivity and frame rate independence

		float zoomValue = zoomAction.ReadValue<float>();
		if (zoomValue > 0)
		{
			camera.fieldOfView = zoomedValue;
        }
		else if (zoomValue < 0)
		{
			camera.fieldOfView = unZoomedValue;
		}

        currentRotation.x += lookValue.x;
		currentRotation.y -= lookValue.y;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -80 , 80 );
		Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);



	}
}
