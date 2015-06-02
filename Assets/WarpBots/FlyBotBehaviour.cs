using UnityEngine;
using System.Collections;

public class FlyBotBehaviour : MonoBehaviour
{
	public enum Behavior
	{
		idle, search,defend, follow, wander, attack, useAbility,death
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public Behavior currentBehaviour;
}

