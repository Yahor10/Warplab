using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Physics2D.IgnoreLayerCollision (10, 13);
		Physics2D.IgnoreLayerCollision (11, 13);
	}
}
