using UnityEngine;
using System.Collections;

public class GrowScaleObstacle : MonoBehaviour {

	// Use this for initialization
	bool upResize;
	bool downResize;

	void Start () {
		upResize = true;
		downResize = false;
		InvokeRepeating("resizeY", 1, 0.1F);
		BoxCollider2D box = GetComponent<BoxCollider2D> ();
		box.collider2D.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void resizeY(){


		if (transform.localScale.y < 1.0 && !upResize) {
			upResize = true;
		}
	
		if (transform.localScale.y > 2.0 && upResize) {
			upResize = false;
		}

		if (upResize) {
			transform.localScale += new Vector3 (0.0F, 0.1f, 0);

		} else {
			transform.localScale -= new Vector3 (0.0F, 0.1f, 0);
		}



		Debug.Log("y scale" + transform.localScale.y);
	}
}
