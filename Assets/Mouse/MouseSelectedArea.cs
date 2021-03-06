﻿using UnityEngine;
using System.Collections;
using UnitySampleAssets._2D;


public class MouseSelectedArea : MonoBehaviour {
	GameObject[] enemies;
	
	// Use this for initialization
	void Start () {
		
		
		if (enemies == null)
			enemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		
	}
	bool clicked = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if(!clicked){
				startVector = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
				
			}			
			clicked = true;
		}
		
		if (Input.GetMouseButtonUp (0)) {
			clicked = false;
		}
	}
	
	void OnGUI ()
	{        
		if (clicked) {
			vd = new Vector2 (Input.mousePosition.x - startVector.x, Screen.height - Input.mousePosition.y - startVector.y);
			Rect rect = new Rect (startVector.x, startVector.y, vd.x, vd.y);
			
			foreach (GameObject enemy in enemies) {
				Vector3 pos = Camera.main.WorldToScreenPoint (enemy.transform.position);
				pos.y = Screen.height - pos.y;	
				
				if(rect.Contains(pos)){
					// enemy selected
					target = enemy.transform;
					
					Debug.Log("selected!");
				}
				
			}
			DrawRectangle (rect, color);        
		}
		
	}
	
	
	private Transform target;
	
	void DrawRectangle (Rect position, Color color)
	{    
		
		// We shouldn't draw until we are told to do so.
		if (Event.current.type != EventType.Repaint) {
			// not repaint event
			return;
		}
		
		// Please assign a material that is using position and color.
		if (material == null) {
			Debug.LogError ("You have forgot to set a material.");
			return;
		}
		
		material.SetPass (0);
		
		// Optimization hint: 
		// Consider Graphics.DrawMeshNow
		GL.Color (color);
		GL.Begin (GL.QUADS);
		GL.Vertex3 (position.x, position.y, 0);
		GL.Vertex3 (position.x + position.width, position.y, 0);
		GL.Vertex3 (position.x + position.width, position.y + position.height, 0);
		GL.Vertex3 (position.x, position.y + position.height, 0);
		GL.End ();
	}
	
	Vector2 startVector;
	Vector2 vd;
	
	
	// Please assign a material that is using position and color.
	public Material material;
	
	public Color color;
	
	
	public void startAttackSelectedTarget(){
		
		GameObject d = GameObject.Find ("FlyBot");
		FlyBotAi bot = d.GetComponent<FlyBotAi>();
		bot.setAttackTarget (target);
	}
	
}