using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circularMotion : MonoBehaviour {

	//public float timeToCompleteOrbit;

	// Use this for initialization
	void Start () {
		
	}

	float x, y;
	float angle =0;
	float speed = (2 * Mathf.PI) / 7; //2*PI in degress is 360.
	float radius=5;

	void Update(){
		angle += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
		x = Mathf.Cos(angle)*radius;
		y = Mathf.Sin(angle)*radius;
		transform.position = new Vector3 (x, y, -1);
	}
}
