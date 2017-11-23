using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sandboxMode : MonoBehaviour {

	Dropdown uiDropdown = GameObject.Find("myDropdown").GetComponent<Dropdown>();
	string chosenValue = uiDropdown.captionText.text;

	//Do a thing when the dropdown value changes.
	void onValueChanged(){
		chosenValue = uiDropdown.captionText.text;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
