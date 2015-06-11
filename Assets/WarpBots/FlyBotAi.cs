using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class FlyBotAi : FlyBotBehaviour {
	
	private Seeker seeker;
	private Rigidbody2D body;
	
	public Transform target;
	
	
	public float nextWayPoint = 2;
	public Path path;
	
	public float speed = 350f;
	
	public ForceMode2D force;
	// Use this for initialization

	
	public Rigidbody2D bullet;

	private Transform flyBotWeapon;
	
	private Transform attackTarget;


	// A mask determining what is ground to the character
	
	public float targetHeading = 110f; //0deg - 359deg
	// Use this for initialization
	
	private float nextFire = 0.0F;
	
	public float fireRate = 0.5F;
	
	private int currWayPoint = 0;

	private bool faceRight = true;

	GameObject s;

	void Start () {

		seeker = GetComponent<Seeker> ();
		body = GetComponent<Rigidbody2D> ();
		
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		
		
		flyBotWeapon = transform.FindChild ("FlyBotWeapon");

		StartCoroutine (UpdatePath ());


		s = GameObject.FindGameObjectWithTag("Pool");

		destroyed = false;
	
	}

	float radius = 50.0f;
	// Update is called once per frame
	void Update () {

		Physics2D.IgnoreLayerCollision (10, 11);

		/*
		foreach (Transform obj in s.transform) {
			if(attackTarget == null){
				attackTarget = obj.gameObject.transform;
				break;
			}
	    }
	    */

		if(attackTarget == null){
			return;
		}

		//Vector3 lookDirection = attackTarget.transform.position - flyBotWeapon.position;
		//float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		//Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//flyBotWeapon.rotation = Quaternion.Slerp(flyBotWeapon.rotation, targetRotation, Time.deltaTime * 20f);

	}
	
	private bool pathisEnded;
	private bool destroyed;

	public void FixedUpdate(){
		if (target == null) {
			return ;
		}
		
		if (path == null) {
			return;
		}
		
		if (currWayPoint >= path.vectorPath.Count) {
			
			
			if(pathisEnded){
				return;
			}
			
			pathisEnded = true;
		}

		switch (currentBehaviour) {
		case Behavior.follow:
			break;
		case Behavior.attack:
			shoot ();
			break;
		}

		pathisEnded = false;

		if (path.vectorPath.Count <= currWayPoint) {
			return;
		}

		Vector3 dir = (path.vectorPath [currWayPoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		body.AddForce (dir, force);
		
		float dist = Vector3.Distance (transform.position, path.vectorPath [currWayPoint]);
		if (dist < nextWayPoint) {
			currWayPoint++;
			return;
		}

	}
	
	public void OnPathComplete(Path p){
		if (!p.error) {
			path = p;
			currWayPoint = 0;
		}
	}
	
	IEnumerator UpdatePath()
	{
		if (target == null) {
			Debug.LogError("UpdatePath target is null");
			return false;
		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		
		yield return new WaitForSeconds(1f/2f);
		StartCoroutine (UpdatePath ());
	}

	void shoot ()
	{
		if(attackTarget == null){
			Debug.LogError("target null");
		
		}
		if (Time.time > nextFire) {	
			nextFire = Time.time + fireRate;
			Rigidbody2D bulletInstance = Instantiate (bullet, flyBotWeapon.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			bulletInstance.velocity = (attackTarget.transform.position - flyBotWeapon.position).normalized * 30f;
			Destroy (bulletInstance.gameObject, 5);
		}

	}

	public void setState(Behavior state){
		currentBehaviour = state;
	}

	public void setAttackTarget(Transform targ){
		Debug.Log("setAttackTarget state");

	
		
		attackTarget = targ;
		setState (Behavior.attack);
	}
}
