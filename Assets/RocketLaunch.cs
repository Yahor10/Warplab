using UnityEngine;
using System.Collections;

public class RocketLaunch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("RocketLaunch Trigger" + other.gameObject.tag);
	}
}
