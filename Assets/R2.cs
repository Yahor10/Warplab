using UnityEngine;
using System.Collections;

public class R2 : MonoBehaviour {

	// Use this for initialization
	public int radius = 20;
	
	private void Start()
	{
		FogOfWarManager.Instance.RegisterRevealer(this);
	}
}
