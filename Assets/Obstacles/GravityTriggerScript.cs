using UnityEngine;
using System.Collections;

public class GravityTriggerScript : MonoBehaviour
{

	// Use this for initialization

	Transform character;
	void Start ()
	{
		character = GameObject.Find ("Character").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		character.rigidbody2D.AddForce (new Vector2 (0, 15), ForceMode2D.Impulse);
	}
}

