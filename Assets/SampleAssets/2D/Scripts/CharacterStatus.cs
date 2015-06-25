using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {


	public int HealthPoint = 20;

	Vector3 startPosition;

	SpawnPlayer spawnScript;
	// Use this for initialization
	void Start () {		 
		Debug.Log ("init char status");
		startPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		GameObject gameObject = GameObject.FindGameObjectWithTag ("GameMaster");
		spawnScript = gameObject.GetComponent<SpawnPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Transform pl;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals ("EnemyMissle")) {
			HealthPoint -=20;
		}

		if (HealthPoint == 0) {
			StartCoroutine (Respawn ());
		}
	}

	IEnumerator Respawn() {
		Debug.Log ("dead");
		renderer.enabled = false;
		yield return new WaitForSeconds(2);
		Debug.Log ("respawn");
		renderer.enabled = true;
		spawnScript.reloadLevel (startPosition);
	}
}
