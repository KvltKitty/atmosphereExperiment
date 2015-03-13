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
	private float _ratio;  //store ratio, calculate at start based on number letters and the alpha gap between
							//this will tell you when to begin fading out beginning of string

	//_fadeInKey and _keyAlpha are derived from the found _ratio
	private int _fadeInKey; //Key which tells it when to begin fading in
	private float _keyAlpha;  //alpha of key when to begin fading in
	private bool hitBox;
	private bool fadeIn;
	private Color color;
	private GUIStyle myStyle;
	
	void Start(){
		if(oneAtTime)
		{
			_text.text = transform.GetComponent<GUIText>().text.ToCharArray ();
			_text.alphaCurrent = 0.0f;
			_text.curChar = 0;
			_text.alphaGap = alphaGap;

		}
		hitBox = false;
		fadeIn = true;
		GetComponent<GUIText>().enabled = false;
		color = transform.GetComponent<GUIText>().color;
		color.a = 0;
		transform.GetComponent<GUIText>().material.color = color;
	}
	
	void Update(){

		if(hitBox && !oneAtTime)
		{
			Fade();
		}
		else if(hitBox && oneAtTime)
		{
			FadeOneIn();
		}
	}


	void OnGUI(){
		if(hitBox && !oneAtTime){
			if(!fadeIn && color.a <= 0.0f){
				Debug.Log ("Destroy");
				Destroy (gameObject);
			}
			GetComponent<GUIText>().material.color = color;
			GetComponent<GUIText>().enabled = true;
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
			if (transform.GetComponent<GUIText>().material.color.a > 0){
				color = transform.GetComponent<GUIText>().material.color;
				color.a -= 0.1f* Time.deltaTime;
				transform.GetComponent<GUIText>().material.color = color;
			}
		}
		else if(fadeIn){
			if (transform.GetComponent<GUIText>().material.color.a < 1){
				color = transform.GetComponent<GUIText>().material.color;
				color.a += 0.1f* Time.deltaTime;
				transform.GetComponent<GUIText>().material.color = color;
				
			}
			if(transform.GetComponent<GUIText>().material.color.a >= 1.0f){
				fadeIn = false;
			}
		}
	}

	void FadeOneIn()
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
	void FadeOneOut()
	{


	}
}
