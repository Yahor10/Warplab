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
		Debug.Log ("bar" + bar.transform.position.y);
	
	}
	private Vector3 target;

	float startTime = 1;

	Vector3 clickedPosition;
	
	// Update is called once per frame
	void Update() {

	}

	void LateUpdate(){
		float xOffset = 2;
		
		if (bar.localScale.x > 0) {
			xOffset = -2;
		}
		else{
			xOffset = 2;
		}

		//transform.position = Vector3.Lerp(transform.position, bar.position + new Vector3(xOffset,-1,0), 0.3f);

		float f =  Mathf.Lerp( transform.position.x, bar.position.x + xOffset, Time.deltaTime * 1f);
		transform.position = new Vector3(f,
		                                                             transform.position.y,
		                                                              transform.position.z);
		Physics2D.IgnoreLayerCollision (10, 11);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{			

	}
}
