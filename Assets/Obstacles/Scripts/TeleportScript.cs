using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

	public GameObject secondPlatform;

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.tag == "Player") {
			otherCollider.gameObject.transform.position = new Vector2(secondPlatform.transform.position.x, secondPlatform.transform.position.y);
		}
	}
}
