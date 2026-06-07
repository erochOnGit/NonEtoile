using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
	InputAction lookAction;
	InputAction zoomAction;
	public float lookSpeed = 10;
	public float zoomedValue = 20;
	public float unZoomedValue;


	bool isZoomed = false;


	public GameObject UI;

	Camera cameraComponent;
	StarManager star;
	private Vector2 currentRotation = Vector2.zero;

	bool haveWon = false;

	void Start()
	{
        Random.InitState(System.DateTime.Now.Second);
        Cursor.visible = false;
		lookAction = InputSystem.actions.FindAction("Look");
		zoomAction = InputSystem.actions.FindAction("Zoom");
		cameraComponent = GetComponent<Camera>();
		unZoomedValue = cameraComponent.fieldOfView;
		star = GameObject.FindAnyObjectByType<StarManager>();
	}

    


    void Update()
    {
		if (!haveWon)
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
	}

	void Victory()
	{
		UI.SetActive(true);
		haveWon = true;
		Cursor.visible = true;
	}

	public void Restart()
	{

		Cursor.visible = false;
		SceneManager.LoadScene(0);
		SceneManager.LoadScene(1,LoadSceneMode.Additive);
	}

}

