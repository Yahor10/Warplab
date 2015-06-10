using UnityEngine;
using System.Collections;
using TwoDHomingMissiles;

public class EnemyMeleeAi : EnemyAi
{
	
	Transform character;
	
	Vector3 startPosition;
	

	private float nextFire = 0.0F;
	
	public float fireRate = 0.7F;
	

	private MissileLaunchScript launchMissle;

	public GameObject[] targets;
	//create a variable to access the JavaScript script  
	  

	void Start () {
		character = GameObject.Find("Character").transform;
		startPosition = transform.position; //store the start position
		launchMissle = transform.GetComponent<MissileLaunchScript>();
	}
	
	float minFindDist = 5;
	
	void moveToPlayer ()
	{
		float dist = Vector2.Distance (character.position, transform.position);
		Vector2 direction = transform.position - character.position;
		float forwardDist = 0;
		if (direction.x > 0) {
			forwardDist = -2;
		}
		else {
			forwardDist = 2;
		}
		if (dist > minFindDist) {
			transform.Translate (new Vector3 (forwardDist * 2 * Time.deltaTime, 0, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(character);
		float dist = 0.0f;
		
		switch (currentState) {
		case Behavior.idle:
			dist = Vector2.Distance (character.position, transform.position);
			if(dist <= 10){
				currentState = Behavior.moveToPlayer;			// player founded
			}
			break;
		case Behavior.moveToPlayer:
			dist = Vector2.Distance (character.position, transform.position);

			if(dist <= 7){
				currentState = Behavior.attack;
			}

			if(dist >= 10){
				Debug.Log("moveToPlayer is far!" + dist);
				currentState = Behavior.returnHome;
				return;
			}

			moveToPlayer ();
			break;
		case Behavior.attack:
			shoot();
			break;
		case Behavior.returnHome:
			float homePos = Vector2.Distance (startPosition, transform.position);
			if(homePos < 1){
				currentState = Behavior.idle;
				Debug.Log("return home");
			}
			transform.position = Vector3.Lerp(transform.position, startPosition, 2 * Time.deltaTime);
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{			
		if (coll.gameObject.tag == "Bullet") {
			HealthPoint -= 20;
		}

		if (HealthPoint == 0) {
			Destroy(gameObject);
		}

	}




	void shoot ()
	{
		if(targets == null){
			Debug.LogError("target null");
			return;
		}

		if (Time.time > nextFire) {	
			nextFire = Time.time + fireRate;
			launchMissle.LaunchMissiles(targets,true,true);
		}		
	}
	
}

