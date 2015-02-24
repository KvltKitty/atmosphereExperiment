using UnityEngine;
using System.Collections;

public class rotateObject : MonoBehaviour {
	public float speed;
	public bool clockWise;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.position, speed * Time.deltaTime, Space.Self);
	}
}
