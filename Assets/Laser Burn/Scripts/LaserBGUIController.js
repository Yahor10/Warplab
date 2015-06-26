//var amplitude = 1.0;
var LT : Light;
var LightOn = true;
var GlowOn = true;
var DustOn = false;
var MouseOn = false;
var Dust : GameObject;

var LightTXT = "Light Off";
var GlowTXT = "Glow On";
var DustTXT = "Dust and Fog On";
var MouseTXT = "Mouse On";



function OnGUI() {
	if (GUI.Button(Rect(Screen.width/2+100,10,100,50),LightTXT)){
			if(LightOn){
			LightOn = false;
			LightTXT = "Light On";
			LT.light.enabled = false;			
			}
			else{
			LightOn = true;
			LightTXT = "Light Off";
			LT.light.enabled = true;
			
			}
	}
	
	if (GUI.Button(Rect(Screen.width/2-100,10,100,50),GlowTXT)){
			if(gameObject.GetComponent("GlowEffect").enabled){
			GlowOn = false;
			GlowTXT = "Glow On";
			gameObject.GetComponent("GlowEffect").enabled = false;
					
			}
			else{
			GlowOn = true;
			GlowTXT = "Glow Off";
			gameObject.GetComponent("GlowEffect").enabled = true;			
			}
	}
	
	//Dust and fog
	if (GUI.Button(Rect(Screen.width/2-300,10,120,50),DustTXT)){
			if(RenderSettings.fog){
			DustOn = false;
			RenderSettings.fog = false;
			DustTXT = "Dust and Fog On";
			Dust.gameObject.active = false;								
			}
			else{
			DustOn = true;
			RenderSettings.fog = true;
			DustTXT = "Dust and Fog Off";
			Dust.gameObject.active = true;
			}
	}
	
		//Use Mouse
	if (GUI.Button(Rect(Screen.width/2+300,10,100,50),MouseTXT)){
			var SPs = GameObject.FindGameObjectsWithTag ("LaserPointer");
						
			if(MouseOn){			
			for (SP in SPs){
				var otherScript: LaserBurn = SP.transform.GetComponent("LaserBurn");
	     		otherScript.UseMousePos = false; 
				}
			MouseOn = false;
			MouseTXT = "Mouse On";
										
			}
			else{
			MouseOn = true;			
			MouseTXT = "Mouse Off";
			for (var SP in SPs){
				 var otherScript2: LaserBurn = SP.transform.GetComponent("LaserBurn");
	     		otherScript2.UseMousePos = true; 
				}
			
			}
	}

	
}//end gui

