﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextStatusScript : MonoBehaviour {

	public GameObject playerObject;

	public GameObject botObject;
	
	void Update () {
		int healthPoint = playerObject.GetComponent<CharacterStatus>().HealthPoint;
		gameObject.GetComponent<Text>().text = "Health: " + healthPoint + "\nBots status: " + botObject.GetComponent<FlyBotAi>().stateText;
	}
}