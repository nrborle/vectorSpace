using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public Transform canvas;

	// Update is called once per frame
	void Update () {
		int count = 0;
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
			count++;
		}
		if (Input.GetKeyDown (KeyCode.Escape) == false && count % 1 == 0){
			Time.timeScale = 1;
			count++;
		}
	}
}