using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SnakeMovent : MonoBehaviour {

	// Use this for initialization
	Vector2 dir = Vector2.right/2;
	List<Transform> tail = new List<Transform>();
	public Transform tailPrefab;

	void Start () {
		InvokeRepeating("Move", 1.0f, 1.0f);  

	}
	
	// Update is called once per frame
	void Update () {
	}


	int step = 0;
	void Move() {
		// Save current position (gap will be here)
		if (step == 5) {
			Debug.Log ("tail" + tail.Count());

			// Add to front of list, remove from the back
			Transform el  = tail.ElementAt(tail.Count - 1 );
			Destroy(el.gameObject);
			tail.RemoveAt(tail.Count - 1);

			return;
		}

		Vector2 v = transform.position;
		
		// Move head into new direction (now there is a gap)
		transform.Translate(dir);


		if (tail.Count() <= 5) {

			Transform g = Instantiate (tailPrefab,
		                                      v,
		                                      Quaternion.identity) as Transform;
			// Keep track of it in our tail list
			tail.Insert (0, g);

		}else if(tail.Count > 5){
			step++;
			// Move last Tail Element to where the Head was
			tail.Last().position = v;
			
			// Add to front of list, remove from the back
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);

		}

	}
}
