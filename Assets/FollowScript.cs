using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class FollowScript : MonoBehaviour {

	private bool rightDir;
	Transform bar;
	float someScale;
	public float speed = 1.5f;

	Vector3 startPoint;

	void Start() {
		bar = GameObject.Find("Character").transform;
		startPoint = transform.position;
	}
	private Vector3 target;

	float startTime = 1;

	Vector3 clickedPosition;
	
	// Update is called once per frame
	void Update() {
		float xOffset = 2;
		Debug.Log (" h" +  bar.localScale.x);

		if (bar.localScale.x > 0) {
			xOffset = -2;
			rightDir =true;
		}
		else{
		    xOffset = 2;
			rightDir = false;
		}
	
		transform.position = Vector3.Lerp(transform.position, bar.position + new Vector3(xOffset,-1,0), 0.3f);
	}
}
