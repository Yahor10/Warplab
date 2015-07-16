using UnityEngine;
using System.Collections;

public class BotTriggerScript : MonoBehaviour {

	public GameObject botObject;

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.gameObject.tag == "Player") {
			FlyBotAi bot = botObject.GetComponent<FlyBotAi>();
			bot.stateText = "Following";
			bot.setState (FlyBotBehaviour.Behavior.follow);
		}
	}
}
