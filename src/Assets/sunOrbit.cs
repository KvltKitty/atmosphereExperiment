using UnityEngine;
using System.Collections;

public class sunOrbit : MonoBehaviour {
	public enum direction{
		right,
		left,
		up,
		down
	}
	public direction dir;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(dir == direction.right){
		transform.RotateAround(Vector3.zero, Vector3.right, speed * Time.deltaTime);
		}
		if(dir == direction.left){
			transform.RotateAround(Vector3.zero, Vector3.left, -speed * Time.deltaTime);
		}
		if(dir == direction.up){
			transform.RotateAround(Vector3.zero, new Vector3(1.0f, 0.0f, 1.0f), speed * Time.deltaTime);
		}
		if(dir == direction.down){
			transform.RotateAround(Vector3.zero, new Vector3(1.0f, 0.0f, -1.0f), speed * Time.deltaTime);
		}
	}
}
