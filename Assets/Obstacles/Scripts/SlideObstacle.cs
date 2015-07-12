using UnityEngine;
using System.Collections;

public class SlideObstacle : MonoBehaviour {

	public Vector2 directionWithSpeed = new Vector2(0, 0.01f);

	public GameObject indicatorTop;

	public GameObject indicatorBottom;

	public float startOffset = 0;

	public float limit = 1;

	public float delay = 2;

	public float blinkingFrequency = 0.5f;

	private Vector2 startPosition;

	private float elapsedTime;

	private float timeToToggle;

	void Start () {
		startPosition = transform.position;
		elapsedTime = 0;
		indicatorTop.renderer.enabled = false;
		indicatorBottom.renderer.enabled = false;
	}
	
	void Update () {
		if (startOffset > 0) {
			startOffset -= Time.deltaTime;
			return;
		}
		if (elapsedTime > 0) {
			elapsedTime -= Time.deltaTime;
			if (directionWithSpeed.x > 0 || directionWithSpeed.y > 0) {
				timeToToggle -= Time.deltaTime;
				if (timeToToggle <= 0) {
					timeToToggle = blinkingFrequency;
					indicatorTop.renderer.enabled = !indicatorTop.renderer.enabled;
				}
			} else {
				timeToToggle -= Time.deltaTime;
				if (timeToToggle <= 0) {
					timeToToggle = blinkingFrequency;
					indicatorBottom.renderer.enabled = !indicatorBottom.renderer.enabled;
				}
			}
			return;
		} else {
			timeToToggle = blinkingFrequency;
			indicatorTop.renderer.enabled = false;
			indicatorBottom.renderer.enabled = false;
		}
		float diff = 0;
		diff = startPosition.x > transform.position.x ? startPosition.x - transform.position.x : transform.position.x - startPosition.x;
		diff = startPosition.y > transform.position.y ? startPosition.y - transform.position.y : transform.position.y - startPosition.y;
		if (diff > limit) {
			directionWithSpeed = new Vector2(-directionWithSpeed.x, -directionWithSpeed.y);
			elapsedTime = delay;
		}
		transform.position = new Vector2((transform.position.x + directionWithSpeed.x), (transform.position.y + directionWithSpeed.y));
	}
}
