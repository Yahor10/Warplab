using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;

public class FlyBotAi : FlyBotBehaviour
{
	
	
	public float flyForce = 0f;

	private Transform character;

	private float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded

	float distToGround;
	
	[SerializeField] private LayerMask whatIsGround;

	Transform groundCheck;

 // A mask determining what is ground to the character

	
	// Use this for initialization
	void Start ()
	{
		character = GameObject.Find ("Character").transform;

		InvokeRepeating("flyState",0.2f,0.2f);

		groundCheck = character.Find("GroundCheck");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate () 
	{
		switch (currentBehaviour) {
		case Behavior.follow:
			flyFollowState();
			break;
		}
	}

	bool upped = false; 

	void  flyFollowState() {
		float xOffset = 1;
		
		if (character.localScale.x > 0) {
			xOffset = -1;
		}
		else {
			xOffset = 1;
		}
		float f = Mathf.Lerp (transform.position.x, character.position.x + xOffset, Time.deltaTime * 1f);
		transform.position = new Vector3 (f, transform.position.y, transform.position.z);

		Physics2D.IgnoreLayerCollision (10, 11);
	}


	void flyState(){

		float dist = Vector2.Distance (transform.position, character.position);
		Debug.Log ("Dist" + dist);
		if (transform.position.y < character.position.y) {			
			rigidbody2D.AddForce (new Vector2 (transform.position.x, flyForce));
		}
		if (transform.position.y >= character.position.y + 5) {
			rigidbody2D.AddForce (new Vector2 (transform.position.x, -flyForce));
		}
	}


}

