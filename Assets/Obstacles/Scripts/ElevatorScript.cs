using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {

	public GameObject top;
	public GameObject platform;
	public GameObject bottom;

	public float topLimit;
	public float bottomLimit;

	private bool wait = false;

	private float topStart;
	private float bottomStart;

	private float direction = 1;

	void Start () {
		topStart = top.transform.position.y;
		bottomStart = bottom.transform.position.y;
	}
	
	void Update () {
		print(platform.transform.position);
		if (wait) {
			if (direction < 0) {
				top.transform.position = new Vector2(top.transform.position.x, top.transform.position.y + (direction / 50));
			} else {
				bottom.transform.position = new Vector2(bottom.transform.position.x, bottom.transform.position.y + (direction / 50));
			}
			return;
		}
		if (top.transform.position.y < topStart) {
			top.transform.position = new Vector2(top.transform.position.x, top.transform.position.y + (-direction / 30));
		}
		if (bottom.transform.position.y > bottomStart) {
			bottom.transform.position = new Vector2(bottom.transform.position.x, bottom.transform.position.y + (-direction / 30));
		}
		if (platform.transform.localPosition.y > topLimit || platform.transform.localPosition.y < bottomLimit) {
			direction = -direction;
			wait = true;
			print(platform.transform.position.y + " " + topLimit + " " + bottomLimit);
		}
		platform.transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y + (direction / 50));
	}

	public void continueMovement() {
		wait = false;
	}
}
