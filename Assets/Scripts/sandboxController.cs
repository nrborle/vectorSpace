using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandboxController : MonoBehaviour {

	public float xScale;
	public float yScale;
	public GameObject Prefab;
	int xValue = TextGetX.xInt;
	int yValue = TextGetY.yInt;
	public Vector2 velocityVector;

	// Use this for initialization
	void Start () {
		velocityVector.x = xValue;
		velocityVector.y = yValue;
		gameObject.GetComponent<Rigidbody2D> ().velocity = velocityVector;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && (Input.mousePosition.y > Screen.height*0.0575) && (Input.mousePosition.y < Screen.height*0.825)) {
			var mousePos = Input.mousePosition;
			Debug.Log (mousePos.y);
			if ((mousePos.y > 60)) {
				mousePos.z = 0.0f;       
				var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
				if (Prefab.name == "Projectile") {
					var projectile = Instantiate (Prefab, objectPos, Quaternion.identity);
					projectile.transform.localScale = new Vector3 (xScale, yScale, 1.0f);
					projectile.GetComponent<Rigidbody2D> ().velocity = velocityVector;
				}else{
					var projectile = Instantiate (Prefab, objectPos, Quaternion.identity);
					projectile.transform.localScale = new Vector3 (xScale, yScale, 1.0f);
					projectile.GetComponent<Rigidbody2D> ().velocity = velocityVector;
					
			}
		}
	}
}
}
