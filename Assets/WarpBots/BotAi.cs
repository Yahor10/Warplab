using UnityEngine;
using System.Collections;

public class BotAi : MonoBehaviour
{


	public enum Behavior
	{
		idle, search,defend, follow, wander, attack, useAbility,death
	}

	private bool rightDir;
	Transform bar;
	float someScale;
	public float speed = 1.5f;

	public Behavior currentBehaviour;
	
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
	
	void followPlayer ()
	{	

		float xOffset = 2;

		if (bar.localScale.x > 0) {
			xOffset = -2;
		}
		else {
			xOffset = 2;
		}
		float f = Mathf.Lerp (transform.position.x, bar.position.x + xOffset, Time.deltaTime * 1f);
		transform.position = new Vector3 (f, transform.position.y, transform.position.z);
	}
	
	void LateUpdate(){
		
		followPlayer ();

		Physics2D.IgnoreLayerCollision (10, 11);
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{			

	}
}

