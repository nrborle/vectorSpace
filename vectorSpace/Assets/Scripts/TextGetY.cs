using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextGetY : MonoBehaviour {
	public static int yInt;
	// Use this for initialization
	void Start () {
		var input = gameObject.GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;

		//or simply use the line below, 
		//input.onEndEdit.AddListener(SubmitName);  // This also works
	}

	private void SubmitName(string arg0){
		//Debug.Log("Y: " + arg0);
		yInt = Int32.Parse(arg0);
	}






	// Update is called once per frame
	void Update () {

	}
}
