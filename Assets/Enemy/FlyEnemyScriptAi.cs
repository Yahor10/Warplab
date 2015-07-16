using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class FlyEnemyScriptAi : EnemyAi {

	private Seeker seeker;
	private Rigidbody2D body;

	public Transform target;


	public float nextWayPoint = 3;
	public Path path;

	public float speed = 350f;

	public ForceMode2D force;
	// Use this for initialization


	private int currWayPoint = 0;
	void Start () {
	
		seeker = GetComponent<Seeker> ();
		body = GetComponent<Rigidbody2D> ();

		seeker.StartPath (transform.position, target.position, OnPathComplete);

		StartCoroutine (UpdatePath ());

	}
	
	// Update is called once per frame
	void Update () {
		float dist = 0.0f;
		
		switch (currentState) {
		case Behavior.idle:
			dist = Vector2.Distance (target.position, transform.position);
			if (dist <= 10) {
				currentState = Behavior.moveToPlayer;			// player founded
			}
			break;
		case Behavior.moveToPlayer:
			dist = Vector2.Distance (target.position, transform.position);
			
			if (dist <= 7) {
				currentState = Behavior.attack;
			}
			
			if (dist >= 10) {
				currentState = Behavior.returnHome;
				return;
			}

			break;
		}
	}

	private bool pathisEnded;

	public void FixedUpdate(){
		if (target == null || currentState == Behavior.idle) {
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

		pathisEnded = false;

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
			return false;
		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);

	
		yield return new WaitForSeconds(1f/2f);
		StartCoroutine (UpdatePath ());
	}
}
