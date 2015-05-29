using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{
	Transform character;
	
	public enum Behavior
	{
		idle, search, confused, moveToPlayer, wander, attack, useAbility
	}
	// Use this for initialization
	
	public Behavior currentState = Behavior.idle;
	void Start () {
		character = GameObject.Find("Character").transform;
		
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
		
		switch (currentState) {
		case Behavior.idle:
			float dist = Vector2.Distance (character.position, transform.position);
			Debug.Log("currentState dist" + dist);
			// player founded
			break;
		case Behavior.moveToPlayer:
			moveToPlayer ();
			break;
		}
		
	}
}

