using UnityEngine;
using System.Collections;

public class EnemyTurretAi : EnemyAi
{

	
	private float nextFire = 0.0F;
	
	public float fireRate = 0.5F;

	Transform character;

	
	public Rigidbody2D bullet;

	// Use this for initialization
	void Start ()
	{
		character = GameObject.Find("Character").transform;

	}
	
	// Update is called once per frame
	void Update ()
	{
	
		float dist = 0.0f;
		
		switch (currentState) {
		case Behavior.idle:
			dist = Vector2.Distance (character.position, transform.position);
			if (dist <= 10) {
				setState(Behavior.attack);
			}
			break;
		case Behavior.attack:
			//stop shoot\
			dist = Vector2.Distance (character.position, transform.position);
			if (dist <= 10) {
				setState(Behavior.idle);
			}
			shoot ();
			break;
		}
	}

	void shoot ()
	{
		if(character == null){
			Debug.LogError("target null");
			setState(Behavior.idle);
			return;
		}
		
		if (Time.time > nextFire) {	
			nextFire = Time.time + fireRate;
			Rigidbody2D bulletInstance = Instantiate (bullet, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			bulletInstance.velocity = (character.transform.position - transform.position).normalized * 30f;
			Destroy (bulletInstance.gameObject, 5);
		}
	}
}

