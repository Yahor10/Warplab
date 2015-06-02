using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class FlyEnemyScriptAi : MonoBehaviour {

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
	
	}

	private bool pathisEnded;

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
			Debug.Log("On path complete");
			path = p;
			currWayPoint = 0;
		}
	}

	IEnumerator UpdatePath()
	{
		if (target == null) {
			Debug.LogError("target is null");
			return false;
		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);

	
		yield return new WaitForSeconds(1f/2f);
		StartCoroutine (UpdatePath ());
	}
}
