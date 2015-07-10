using UnityEngine;
using System.Collections;

public class Revelear : MonoBehaviour {

	public int radius;
	
	private void Start()
	{
		FogOfWarManager.Instance.RegisterRevealer(this);
	}

	
	private void Update()
	{

	
	}
}
