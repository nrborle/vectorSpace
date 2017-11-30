using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraZoom : MonoBehaviour {

	public Camera OrthographicCamera;
	public Button zoomIn;
	public Button zoomOut;

	void Update(){
		OrthographicCamera.orthographicSize = 5.0f;
	}
}