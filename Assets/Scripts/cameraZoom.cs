using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraZoom : MonoBehaviour {

	public Camera OrthographicCamera;
	public Button zoomIn;
	public Button zoomOut;


	void Start(){
		zoomIn.onClick.AddListener(performZoomIn);
		zoomOut.onClick.AddListener(performZoomOut);
	}
		

	void performZoomIn(){
		if (OrthographicCamera.orthographicSize - 5 > 0) {
			Debug.Log ("Zoom In!");
			OrthographicCamera.orthographicSize -= 5;
		}
	}

	void performZoomOut(){
		if (OrthographicCamera.orthographicSize + 5 < 50) {
		Debug.Log("Zoom Out!");
		OrthographicCamera.orthographicSize += 5;
		}
	}

}