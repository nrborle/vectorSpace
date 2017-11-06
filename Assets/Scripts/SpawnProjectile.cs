using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour {

	public float xScale;
	public float yScale;

	public GameObject Projectile;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && (Input.mousePosition.y > Screen.height*0.0575)) {
			var mousePos = Input.mousePosition;
			Debug.Log (mousePos.y);
			if ((mousePos.y > 60)) {
				mousePos.z = 0.0f;       
				var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
				var projectile = Instantiate (Projectile, objectPos, Quaternion.identity);
				projectile.transform.localScale = new Vector3 (xScale,yScale,1.0f);
			}
		}
	}
} 