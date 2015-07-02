using UnityEngine;
using System.Collections;

public class FlyBotBehaviour : BaseBotAi
{
	public enum Behavior
	{
		idle, search,defend, follow,followPath, wander, attack, useAbility,death
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

	public void setState(Behavior state){
		currentBehaviour = state;
	}
}

