using UnityEngine;
using System.Collections;

public class FlyPlatformScript : MonoBehaviour {

	float y;
	// Use this for initialization
	void Start () {
		GameObject tr = GameObject.FindGameObjectWithTag ("Player") ;
		//Physics2D.IgnoreCollision(tr.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void fly(){
		Debug.Log ("y pos" + transform.position.y);
		transform.position = new Vector3 (transform.position.x , transform.position.y + 0.1f, 0);

		if (transform.position.y >= 8) {
			CancelInvoke("fly");
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log ("OnCollisionEnter2D trig:" + col.gameObject.tag);

	}

	public void startFly(){
		InvokeRepeating("fly", 0.1f, 0.1f);  
	}

}
