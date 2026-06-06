using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	InputAction lookAction;
	public float lookSpeed;

    void Start()
	{
		lookAction = InputSystem.actions.FindAction("Look");
	}

    void Update()
    {
		Vector2 lookValue = lookAction.ReadValue<Vector2>();
		lookValue *= Time.deltaTime * lookSpeed; // Adjust sensitivity and frame rate independence

		this.transform.Rotate(lookValue.x, lookValue.y, 0);
	}
}
