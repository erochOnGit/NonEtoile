using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	InputAction lookAction;
	InputAction zoomAction;
	public float lookSpeed = 10;
	public float zoomedValue = 20;
	public float unZoomedValue;
	Camera cameraComponent; 

	private Vector2 currentRotation = Vector2.zero;
	void Start()
	{
		lookAction = InputSystem.actions.FindAction("Look");
		zoomAction = InputSystem.actions.FindAction("Zoom");
		cameraComponent = GetComponent<Camera>();
		unZoomedValue = cameraComponent.fieldOfView;
    }

    void Update()
    {
		Vector2 lookValue = lookAction.ReadValue<Vector2>();
		lookValue *= Time.deltaTime * lookSpeed; // Adjust sensitivity and frame rate independence

		float zoomValue = zoomAction.ReadValue<float>();
		if (zoomValue > 0)
		{
			cameraComponent.fieldOfView = zoomedValue;
			lookSpeed = 0.5f;

        }
		else if (zoomValue < 0)
		{
			cameraComponent.fieldOfView = unZoomedValue;
			lookSpeed = 10f;
		}

        currentRotation.x += lookValue.x;
		currentRotation.y -= lookValue.y;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -80 , 80 );
		Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);



	}
}
