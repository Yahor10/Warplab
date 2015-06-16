using UnityEngine;
using System.Collections;

public class EnergyShieldScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag.Equals("EnemyMissle")){
			TwoDHomingMissiles.MissileController controller = other.gameObject.GetComponent<TwoDHomingMissiles.MissileController>();
			other.gameObject.SetActive(false);
			controller.GracefullyDestroyMissile(other.transform.position);
		}
		
	}


}
