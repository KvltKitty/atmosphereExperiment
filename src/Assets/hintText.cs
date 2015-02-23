using UnityEngine;
using System.Collections;
using System.Text;

public class hintText : MonoBehaviour {
	public class TextInfo {
		public char[] text;
		public float alphaCurrent; //use to tell when current letter has reached point to begin fading in next letter
		public int curChar;

		public float alphaGap; //gap between beginning to fade in each character

		//setup to allow you to iterate through a list and fade in one character at a time
	}

	public bool oneAtTime;

	public TextInfo _text;
	public float alphaGap;
	public float speed;
	bool hitBox;
	bool fadeIn;
	Color color;
	GUIStyle myStyle;
	
	void Start(){
		if(oneAtTime)
		{
			_text.text = transform.guiText.text.ToCharArray ();
			_text.alphaCurrent = 0.0f;
			_text.curChar = 0;
			_text.alphaGap = alphaGap;

		}
		hitBox = false;
		fadeIn = true;
		guiText.enabled = false;
		color = transform.guiText.color;
		color.a = 0;
		transform.guiText.material.color = color;
	}
	
	void Update(){

		if(hitBox && !oneAtTime)
		{
			Fade();
		}
		else if(hitBox && oneAtTime)
		{
			FadeOne();
		}
	}


	void OnGUI(){
		if(hitBox && !oneAtTime){
			if(!fadeIn && color.a <= 0.0f){
				Debug.Log ("Destroy");
				Destroy (gameObject);
			}
			guiText.material.color = color;
			guiText.enabled = true;
		}
		else if(hitBox &&oneAtTime){
			StringBuilder _cur = new StringBuilder();
			for(int i = 0; i < _text.curChar; i++)
			{

			}


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

	void FadeOne()
	{
		if(_text.curChar == 0)
		{
			if(_text.alphaCurrent >= _text.alphaGap){
				if(_text.curChar + 1 < _text.text.Length)
				{
					_text.curChar++;
					_text.alphaCurrent = 0.0f;
				}
			}

		}

	}
}
