using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {

	public int HealthPoint = 20;
	
	SpawnPlayer spawnScript;

	void Start () {		 
		GameObject gameObject = GameObject.FindGameObjectWithTag ("GameMaster");
		spawnScript = gameObject.GetComponent<SpawnPlayer> ();
	}

	Transform pl;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals ("EnemyMissle")) {
			if (HealthPoint > 0) {
				HealthPoint -=20;
			}
		}

		if (HealthPoint <= 0) {
			StartCoroutine (Respawn ());
		}
	}

	IEnumerator Respawn() {
		Debug.Log ("dead");
		renderer.enabled = false;
		yield return new WaitForSeconds(2);
		Debug.Log ("respawn");
		HealthPoint = 20;
		renderer.enabled = true;
		spawnScript.reloadLevel ();
	}
}
