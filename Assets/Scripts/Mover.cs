using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mover : MonoBehaviour {

	int xValue = TextGetX.xInt;
	int yValue = TextGetY.yInt;

	public Vector2 velocityVector;
	void Start (){
		velocityVector.x = xValue;
		velocityVector.y = yValue;
		gameObject.GetComponent<Rigidbody2D> ().velocity = velocityVector;
		//= transform.forward * speed;
	}
}

//	InputField xInputField;
//	InputField yInputField;
//
//	Vector2 getVector2(string x, string y){
//		int xValue = int.Parse (x);
//		int yValue = int.Parse (y);
//		return Vector2 (x,y);
//	}


	
	//= getVector2(xInputField.text, yInputField.text);

	//public Vector2 velocityVector;
