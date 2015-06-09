using UnityEngine;
using System.Collections;

public class WallCollusion : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}

	public float speed;
	
	private Vector3 currentDirection = Vector3.zero;
	
	void Update()
	{
		if (currentDirection.Equals(Vector3.zero))
		{
			Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			if (!inputDirection.Equals(Vector3.zero))
			{
				currentDirection = inputDirection;
				this.rigidbody2D.velocity = currentDirection * speed;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{

	}


}
