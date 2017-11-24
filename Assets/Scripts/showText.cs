using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showText : MonoBehaviour {

	public Text textShow = null;

	public void updateText(string word){
		textShow.text = word;
	}
}
