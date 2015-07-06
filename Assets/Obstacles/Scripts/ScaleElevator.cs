using UnityEngine;
using System.Collections;

public class ScaleElevator : MonoBehaviour {

	// Use this for initialization
	bool upResize;
	bool downResize;
	bool wait;
	
	public Transform triggerTarget;
	FlyPlatformScript flyScript;
	
	void Start () {
		upResize = true;
		downResize = false;
		wait = false;
		InvokeRepeating("resizeLocaleScaleY", 1, 0.1F);
		flyScript = triggerTarget.GetComponent<FlyPlatformScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void resizeLocaleScaleY(){
		
		
		if (transform.localScale.y < 1.0 && !upResize) {
			upResize = true;
			wait = true;
			CancelInvoke("resizeLocaleScaleY");
		}
		
		if (transform.localScale.y > 2.0 && upResize) {
			upResize = false;
			flyScript.startFly();
		}
		
		if (upResize) {
			transform.localScale += new Vector3 (0.0F, 0.1f, 0);
			
		} else {
			transform.localScale -= new Vector3 (0.0F, 0.1f, 0);
		}
		
		
		
	}
}
