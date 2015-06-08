using UnityEngine;
using System.Collections;

public class EnemyMeleeAi : MonoBehaviour
{
	
	Transform character;
	
	public enum Behavior
	{
		idle, search, confused, moveToPlayer, wander, attack, useAbility,returnHome
	}
	// Use this for initialization
	
	public Behavior currentState = Behavior.idle;
	
	Vector3 startPosition;
	
	void Start () {
		character = GameObject.Find("Character").transform;
		startPosition = transform.position; //store the start position
	}
	
	float minFindDist = 2;
	
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
			if(dist <= 4){
				currentState = Behavior.moveToPlayer;			// player founded
			}
			break;
		case Behavior.moveToPlayer:
			dist = Vector2.Distance (character.position, transform.position);
			if(dist <= 2){
			}
			if(dist >= 5){
				Debug.Log("moveToPlayer is far!" + dist);
				currentState = Behavior.returnHome;
				return;
			}
			moveToPlayer ();
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
	
}

