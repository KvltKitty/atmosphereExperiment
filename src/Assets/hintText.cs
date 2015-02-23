using UnityEngine;
using System.Collections;

public class hintText : MonoBehaviour {


	bool hitBox;
	bool fadeIn;
	Color color;
	GUIStyle myStyle;
	
	void Start(){
		hitBox = false;
		fadeIn = true;
		guiText.enabled = false;
		color = transform.guiText.color;
		color.a = 0;
		transform.guiText.material.color = color;
	}
	
	void Update(){

		if(hitBox){
			Fade();
		}
	}


	void OnGUI(){
		if(hitBox){
			guiText.material.color = color;
			guiText.enabled = true;
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Player")){
			hitBox = true;

		}
	}
	void Fade(){
		if(!fadeIn){
		if (transform.guiText.material.color.a > 0){
			color = transform.guiText.material.color;
			color.a -= 0.1f* Time.deltaTime;
			transform.guiText.material.color = color;

		}
		}
		else if(fadeIn){
			if (transform.guiText.material.color.a < 1){
				color = transform.guiText.material.color;
				color.a += 0.1f* Time.deltaTime;
				transform.guiText.material.color = color;
				
			}
			if(transform.guiText.material.color.a >= 1.0f){
				fadeIn = false;
			}
		}
	}
}
