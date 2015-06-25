using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	// Use this for initialization

	public Transform player;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void reloadLevel(){
		Destroy (player.gameObject);
		Application.LoadLevel(Application.loadedLevel);
	}
}
