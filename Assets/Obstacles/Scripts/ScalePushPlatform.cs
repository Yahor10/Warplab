using UnityEngine;
using System.Collections;

public class ScalePushPlatform : MonoBehaviour {

	bool RightResize;

	public float invokeStartTime = 1;

	public float scaleRightSpeed = 0.2F;

	public float scaleLeftSpeed = 0.1F;

	// Use this for initialization
	void Start () {
		RightResize = true;
		InvokeRepeating("resizeLocaleScaleYX", invokeStartTime, 0.1F);
	}

	void Update () {
	}

	public void resizeLocaleScaleYX(){
		if (transform.localScale.x < 0.6 && !RightResize) {
			RightResize = true;
		}
		
		if (transform.localScale.x > 2.0 && RightResize) {
			RightResize = false;
		}
		
		if (RightResize) {
			transform.localScale += new Vector3 (scaleRightSpeed, 0.0f, 0);
			
		} else {
			transform.localScale -= new Vector3 (scaleLeftSpeed, 0.0f, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals ("Player")) {
			Rigidbody2D body  = col.gameObject.GetComponent<Rigidbody2D>();
			body.AddForce (Vector2.right * 400 * 10); // TODO find more elegant way
		}
	}

}
