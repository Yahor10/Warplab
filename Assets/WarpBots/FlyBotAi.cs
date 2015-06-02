using UnityEngine;
using System.Collections;

public class FlyBotAi : FlyBotBehaviour
{
	
	
	public float flyForce = 0f;

	private Transform character;

	// Use this for initialization
	void Start ()
	{
		character = GameObject.Find("Character").transform;

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate () 
	{
		if (transform.position.y < 0) {
			rigidbody2D.AddForce (new Vector2 (-1, flyForce));
		}

		switch (currentBehaviour) {
		case Behavior.follow:
			flyFollowState();
			break;
		}
	}

	bool upped = false; 

	void  flyFollowState() {
		float xOffset = 2;
		
		if (character.localScale.x > 0) {
			xOffset = -2;
		}
		else {
			xOffset = 2;
		}
		float f = Mathf.Lerp (transform.position.x, character.position.x + xOffset, Time.deltaTime * 1f);
		transform.position = new Vector3 (f, transform.position.y, transform.position.z);

		Physics2D.IgnoreLayerCollision (10, 11);
	}
	
}

