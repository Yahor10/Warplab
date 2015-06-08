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

	public Rigidbody2D bullet;

	private Transform flyBotWeapon;

	private Transform attackTarget;


 // A mask determining what is ground to the character

	public float targetHeading = 110f; //0deg - 359deg
	// Use this for initialization

	private float nextFire = 0.0F;

	public float fireRate = 0.5F;

	void Start ()
	{
		character = GameObject.Find ("Character").transform;

		InvokeRepeating("flyState",0.2f,0.2f);

		groundCheck = character.Find("GroundCheck");

		flyBotWeapon = transform.FindChild ("FlyBotWeapon");
		
	}


	// Update is called once per frame
	void Update ()
	{
		Vector3 lookDirection = GameObject.Find("FlyEnemy").transform.position - flyBotWeapon.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		flyBotWeapon.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 20f);

	}

	void FixedUpdate () 
	{

		switch (currentBehaviour) {
		case Behavior.follow:
			flyFollowState();
			break;
		case Behavior.attack:
			shoot ();
			break;
		}
	}

	
	void shoot ()
	{
		
		if (Time.time > nextFire) {
			if(attackTarget == null){
				Debug.LogError("target null");
			}
			
			nextFire = Time.time + fireRate;
			Rigidbody2D bulletInstance = Instantiate (bullet, flyBotWeapon.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			bulletInstance.velocity = (attackTarget.transform.position - flyBotWeapon.position).normalized * 30f;
			Destroy (bulletInstance.gameObject, 5);
		}
	}

	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		if (hit) {
			Debug.Log ("Name" + hit.collider.gameObject.name);
			Debug.Log ("hit " + hit.collider.gameObject.tag);
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
		if (transform.position.y < character.position.y) {			
			rigidbody2D.AddForce (new Vector2 (transform.position.x, flyForce));
		}
		if (transform.position.y >= character.position.y + 5) {
			rigidbody2D.AddForce (new Vector2 (transform.position.x, -flyForce));
		}
	}

	public void setAttackState(){
		currentBehaviour = Behavior.attack;
	}

	public void setAttackTarget(Transform target){
		if (target == null) {
			Debug.LogError ("target attack is null!");
			return;
		}

		attackTarget = target;
		setAttackState ();

	}

	void OnCollisionEnter2D(Collision2D coll)
	{			
	}

	
	void OnMouseDown(){

	}

	void OnMouseUp() {
	}

	void OnMouseDrag(){

	}



	
}

