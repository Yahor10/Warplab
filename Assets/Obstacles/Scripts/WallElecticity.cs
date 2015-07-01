using UnityEngine;
using System.Collections;

public class WallElecticity : MonoBehaviour {

	// Use this for initialization

	Color[] colors = {Color.blue,Color.black,Color.red,Color.green};
	private SpriteRenderer render;
	void Start () {	
		render = GetComponent<SpriteRenderer> ();
		StartCoroutine (WaitAndPrint (1.0f));
	}
	
	// Update is called once per frame
	void Update () {

	}


	IEnumerator WaitAndPrint(float waitTime) {
		while (true) { 
			yield return new WaitForSeconds (waitTime);
			render.color = colors[Random.Range(0,3)];
		}
	}
}
