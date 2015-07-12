using UnityEngine;
using System.Collections;

public class ElevatorPlatformScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "ElevatorPlatformPusher") {
			transform.parent.gameObject.GetComponent<ElevatorScript>().continueMovement();
		}
    }
}
