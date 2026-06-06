using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	InputAction lookAction;
	public float lookSpeed;

	private Vector2 currentRotation = Vector2.zero;
	void Start()
	{
		lookAction = InputSystem.actions.FindAction("Look");
	}

    void Update()
    {
		Vector2 lookValue = lookAction.ReadValue<Vector2>();
		lookValue *= Time.deltaTime * lookSpeed; // Adjust sensitivity and frame rate independence


		currentRotation.x += lookValue.x;
		currentRotation.y -= lookValue.y;
		currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
		currentRotation.y = Mathf.Clamp(currentRotation.y, -80 , 80 );
		Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);

	}
}
