using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlCamara : MonoBehaviour
{
	public float mouseSensibility = 500f;
	public Transform playerBody;
	public Transform brazo;

	float xRotation = 0f;
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void FixedUpdate()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.fixedDeltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.fixedDeltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -30f, 10f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		brazo.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);


	}

}