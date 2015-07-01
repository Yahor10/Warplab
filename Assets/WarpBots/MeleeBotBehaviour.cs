using UnityEngine;
using System.Collections;

public class MeleeBotAi : BaseBotAi
{

	public enum Behavior
	{
		idle, search,defend, follow, wander, attack, useAbility,death
	}

	public Behavior currentBehaviour;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void setState(Behavior state){
		currentBehaviour = state;
	}
	
}

