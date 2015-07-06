using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

	// Use this for initialization
	private bool paused; 
	void Start ()
	{
	
		paused = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("escape")) {
			paused =! paused;
		}

		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}

		if ( Input.GetMouseButton( 1 ) )
		{
			MouseX = Input.GetAxis("Mouse X");
			MouseY = Input.GetAxis("Mouse Y");
			Vector3	CameraPos = new Vector3(- MouseX, -MouseY, 0);

			Camera.mainCamera.transform.position +=CameraPos;
		}
	}

	float MouseX;
	float MouseY;
}

