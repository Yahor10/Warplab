using UnityEngine;
using System.Collections;

public class BotAi : MeleeBotAi
{
	

	private bool rightDir;
	Transform bar;
	float someScale;
	public float speed = 1.5f;
		
	Vector3 startPoint;

	GameObject energyShield;

	public float detectEnemyRadius = 10f;
		
	void Start() {
		bar = GameObject.Find("Character").transform;
		startPoint = transform.position;
		Debug.Log ("bar" + bar.transform.position.y);
		energyShield = transform.Find("Energy_shield").gameObject;
	
		
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

		switch (currentBehaviour) {
		case Behavior.follow:
			Collider2D[] detectObjects = Physics2D.OverlapCircleAll(transform.position,detectEnemyRadius);
			foreach(Collider2D detect in detectObjects){
				if(detect.gameObject.tag.Equals("EnemyMissle")){
					setState(Behavior.defend);	
					break;
				}
			}
			followPlayer ();
			energyShield.renderer.enabled = false;
			break;
		case Behavior.defend:
			// stop follow
			energyShield.renderer.enabled = true;
			StartCoroutine (checkDefendState(5.0f));
			break;
		}


		Physics2D.IgnoreLayerCollision (10, 11);
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{			

	}

	IEnumerator checkDefendState(float waitTime) {
		while(true){
			yield return new WaitForSeconds (waitTime);
			Collider2D[] detectObjects = Physics2D.OverlapCircleAll(transform.position,detectEnemyRadius);
			foreach(Collider2D detect in detectObjects){
				if(detect.gameObject.tag.Equals("EnemyMissle")){
					setState(Behavior.defend);	
					return true;
				}
			} // TODo refactor speed
			setState(Behavior.follow);
		}
	}
}

