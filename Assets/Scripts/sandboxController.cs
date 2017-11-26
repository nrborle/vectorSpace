using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sandboxController : MonoBehaviour {

	public float xScale;
	public float yScale;
	public GameObject PrefabStar;
	public GameObject PrefabPlanet;
	public Text selectionText = null;
	int xValue = TextGetX.xInt;
	int yValue = TextGetY.yInt;
	public Vector2 velocityVector;

	// Use this for initialization
	void Start () {
		velocityVector.x = xValue;
		velocityVector.y = yValue;
		//gameObject.GetComponent<Rigidbody2D> ().velocity = velocityVector;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && (Input.mousePosition.y > Screen.height*0.0575) && (Input.mousePosition.y < Screen.height*0.825)) {
			var mousePos = Input.mousePosition;
			Debug.Log (mousePos.y);
			if ((mousePos.y > 60)) {
				mousePos.z = 0.0f;       
				var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
				if (selectionText.text == "Planet") {
					//Planet
					var projectile = Instantiate (PrefabPlanet, objectPos, Quaternion.identity);
					projectile.transform.localScale = new Vector3 (xScale, yScale, 1.0f);
					projectile.GetComponent<Rigidbody2D> ().velocity = velocityVector;
					Debug.Log(selectionText.text);
				} else if (selectionText.text == "Star") {
					//Star
					var projectile = Instantiate (PrefabStar, objectPos, Quaternion.identity);
					projectile.transform.localScale = new Vector3 (xScale, yScale, 1.0f);
					projectile.GetComponent<Rigidbody2D> ().velocity = velocityVector;
					Debug.Log(selectionText.text);
				} else if (selectionText.text == "Delete") {
					//Deleting
					Debug.Log(selectionText.text);
					DestroyAllGameObjects ();
				} else if (selectionText.text == null) {
					//Null
					Debug.Log(selectionText.text);
				} else {
					//Not Null and not planet, star, or delete!!!
					Debug.Log(selectionText.text);
				}
		}
	}
}

	public void DestroyAllGameObjects(){
		var planets = GameObject.FindGameObjectsWithTag ("Projectile");
		var stars = GameObject.FindGameObjectsWithTag ("Gravity");
		foreach (var planet in planets){
			Destroy(planet);
		}
		foreach (var star in stars){
			Destroy(star);
		}
	}

}