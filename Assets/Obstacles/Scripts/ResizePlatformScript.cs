using UnityEngine;
using System.Collections;

public class ResizePlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//StartCoroutine (Resize ());
		InitStyles ();
	}

	private Vector3 v3Scale;
	// Update is called once per frame
	void Update () {
	
	}

	/*
	IEnumerator Resize(){
	
		while (true) {
			yield return new WaitForSeconds (0.1f);

			if(upSize){
				transform.position -= new Vector3(0.1f,0.1f,0f);
				v3Scale = new Vector3(0.1f,0.1f,0f);
			}else{
				v3Scale = new Vector3(-0.1f,-0.1f,0f);
				transform.position += new Vector3(0.1f,0.1f,0f);
			}

			if(transform.localScale.x <=0.5 && !upSize){
				upSize = true;
			}else if(transform.localScale.x >= 1.7 && upSize){
				upSize = false;
			}

			transform.localScale += v3Scale;	


	}		}*/

	float halfWidth = 100 / 2;
	float halfHeight = 80 / 2;
	
	float resize = 0;

	bool upResize = true;

	public void OnGUI(){


		Bounds b = transform.renderer.bounds;
		Camera cam = Camera.main;
		
		//The object is behind us
		if (cam.WorldToScreenPoint (b.center).z < 0) return;
		
		//All 8 vertices of the bounds
		pts[0] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
		pts[1] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
		pts[2] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
		pts[3] = cam.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
		pts[4] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z));
		pts[5] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z));
		pts[6] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z));
		pts[7] = cam.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z));
		
		//Get them in GUI space
		for (int i=0;i<pts.Length;i++) pts[i].y = Screen.height-pts[i].y;
		
		//Calculate the min and max positions
		Vector3 min = pts[0];
		Vector3 max = pts[0];
		for (int i=1;i<pts.Length;i++) {
			min = Vector3.Min (min, pts[i]);
			max = Vector3.Max (max, pts[i]);
		}
		
		//Construct a rect of the min and max positions and apply some margin


		if (r.width < 50 && !upResize) {
			upResize = true;
		}

		if (r.width > 250 && upResize) {
			upResize = false;
		}

		if (upResize) {
			resize += 0.35f;
			r = Rect.MinMaxRect (min.x - resize, min.y - resize, max.x + resize, max.y + resize);
		} else {
			resize -= 0.35f;
			r = Rect.MinMaxRect (min.x - resize, min.y - resize, max.x + resize, max.y + resize);
		}

		//Render the box
		InitStyles ();
		GUI.Box (r,"",currentStyle);

   }
	Rect r;
	private Vector3[] pts = new Vector3[8];
	private GUIStyle currentStyle = null;

	private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
		}
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
	
	
}
