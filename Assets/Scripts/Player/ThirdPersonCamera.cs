using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	const float Y_ANGLE_MIN = -50;
	const float Y_ANGLE_MAX = 50;

	public Transform lookAt;
	Transform camTransform;

	public Camera cam;

	float distance = 3.87f;
	float currentX = 0;
	float currentY = 0;

	PlayerController pController;

	void Start(){
		if (cam == null)
			Debug.LogError ("Camera not dragged!");
		
		camTransform = cam.GetComponent<Transform> ();
		if (camTransform == null)
			Debug.LogError ("Camera transform not founded!");

		pController = GetComponent<PlayerController> ();
		if (pController == null)
			Debug.LogError ("PlayerController not founded!");
	}

	void Update(){
		if (pController.isFirstPlayer) {
			currentX += Input.GetAxis ("Mouse X");
			currentY += -Input.GetAxis ("Mouse Y");
		} else {
			currentX += Input.GetAxis ("Left Joy X");
			currentY += -Input.GetAxis ("Left Joy Y");
		}

		currentY = Mathf.Clamp (currentY,Y_ANGLE_MIN,Y_ANGLE_MAX);

		lookAt.forward = new Vector3(lookAt.position.x - camTransform.position.x,lookAt.forward.y,lookAt.position.z - camTransform.position.z);
	}

	void LateUpdate(){
		Vector3 dir = new Vector3 (0,0,-distance);
		Quaternion rotation = Quaternion.Euler (currentY,currentX,0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}
