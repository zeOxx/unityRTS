using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	private Vector3 previousMousePosition;
	private bool MMDown = false;
	public GameObject camera;
	public GameObject groundPlane;
	private float cameraHeight = 15;
	// Use this for initialization
	void Start () {
		// Load config values
		previousMousePosition = new Vector3 ();
	}
	
	// Update is called once per frame
	void Update () {
		CameraHandler ();
		
		// Debug.Log (Input.mousePosition);
	}

	void CameraHandler() {
		Vector3 position = Input.mousePosition;

		// Hover camera a certain dinstance above the map
		Transform transform = camera.transform.Find("Main Camera");
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		Ray ray = new Ray (camera.transform.position, fwd);
		if (groundPlane.collider.Raycast (ray, out hit, 30)) {
			Debug.DrawLine (camera.transform.position, hit.point);
			Vector3 camPos = camera.transform.position;
			camera.transform.position = new Vector3(camPos.x, cameraHeight + hit.point.y, camPos.z);
		}


		// Move camera with middle mouse button
		if (Input.GetAxis ("MouseMiddle") == 1) {
			if (MMDown) {
				Vector3 move = previousMousePosition - position;
				move = new Vector3(move.x * 0.05f, 0, move.y * 0.05f);
				//Debug.Log(move);
				camera.transform.Translate (move);
			}
			else {
				MMDown = true;
			}
			previousMousePosition = Input.mousePosition;
		} else {
			MMDown = false;
		}

		// Move camera with 
		if (Input.GetAxis ("CameraLeft") == 1) {
			camera.transform.Translate (new Vector3 (-0.25f, 0, 0));
		}
		if (Input.GetAxis ("CameraRight") == 1) {
			camera.transform.Translate (new Vector3 (0.25f, 0, 0));
		}
		if (Input.GetAxis ("CameraUp") == 1) {
			camera.transform.Translate (new Vector3 (0, 0, 0.25f));
		}
		if (Input.GetAxis ("CameraDown") == 1) {
			camera.transform.Translate (new Vector3 (0, 0, -0.25f));
		}

		// Check if middle mouse is pressed and mouse is inside game screen
		if (!MMDown && IsMouseOnScreen()) {
			// Move camera when touching the edges of the screen
			if (position.x <= 10 && position.x >= 0) {
				camera.transform.Translate (new Vector3 (-0.25f, 0, 0));
			}

			if (position.x >= Screen.width - 10 && position.x <= Screen.width) {
				camera.transform.Translate (new Vector3 (0.25f, 0, 0));
			}

			if (position.y <= 10 && position.y >= 0) {
				camera.transform.Translate (new Vector3 (0, 0, -0.25f));
			}

			if (position.y >= Screen.height - 10 && position.y <= Screen.height) {
				camera.transform.Translate (new Vector3 (0, 0, 0.25f));
			}
		}
		if (Input.GetAxis ("MouseScrollWheel") != 0) {
			cameraHeight += Input.GetAxis ("MouseScrollWheel") * 4;
			if (cameraHeight <= 10) {
				cameraHeight = 10;
			}
			else if (cameraHeight >= 15) {
				cameraHeight = 15;
			}
		}
	}

	bool IsMouseOnScreen() {
		if (Input.mousePosition.x >= 0
			&& Input.mousePosition.x <= Screen.width
			&& Input.mousePosition.y >= 0
			&& Input.mousePosition.y <= Screen.height) {
			return true;
		}
		return false;
	}
}
