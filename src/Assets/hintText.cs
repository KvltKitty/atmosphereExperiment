using UnityEngine;
using System.Collections;

public class hintText : MonoBehaviour {


	bool hitBox;
	Color color;
	GUIStyle myStyle;
	
	void Start(){
		hitBox = false;
		guiText.enabled = false;
		color = transform.guiText.color;
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
			Debug.Log ("BOOM");
		}
	}
	void Fade(){
		
		if (transform.guiText.material.color.a > 0){
			color = transform.guiText.material.color;
			color.a -= 0.1f* Time.deltaTime;
			transform.guiText.material.color = color;

		}
	}
}
