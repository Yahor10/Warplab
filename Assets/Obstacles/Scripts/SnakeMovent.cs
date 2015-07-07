using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class SnakeMovent : MonoBehaviour {

	public Transform tailPrefab;

	public Vector2 direction = new Vector2(1, 0);

	public float stepWidth = 0.6f;

	public int limit = 10;

	public int length = 3;

	public float stepSpeed = 1.0f;

	public bool reverse = false;

	private List<Transform> tail = new List<Transform>();

	private Vector2 initialPosition;

	private int step = 0;

	void Start () {
		initialPosition = transform.position;
		InvokeRepeating("Move", stepSpeed, stepSpeed);
	}

	void Move() {
		if (tail.Count < length && step <= limit) {
			step++;
			Transform tailPart = Instantiate(tailPrefab, new Vector2(initialPosition.x + (step * (direction.x * stepWidth)), initialPosition.y + (step * (direction.y * stepWidth))), Quaternion.identity) as Transform;
			tail.Add(tailPart);
		} else if (tail.Count == length && step <= limit) {
			step++;
			for (int i = 0; i < length; i++) {
				tail[i].Translate(new Vector2(direction.x * stepWidth, direction.y * stepWidth));
			}
		} else if (step > limit) {
			if (tail.Count == 0) {
				step = 0;
			} else if (reverse) {
				direction = new Vector2(-direction.x, -direction.y);
				step = 0;
			} else {
				Destroy(tail[0].gameObject);
				tail.RemoveAt(0);
			}
		}

	}
}
/*
if (step >= limit && step <= limit + length) {
				tail.RemoveAt(0);
				if (reverse) {
					
				}
			} else {
				tail.Last().position = v;
			
				tail.Insert(0, tail.Last());
				tail.RemoveAt(tail.Count - 1);
			}
*/