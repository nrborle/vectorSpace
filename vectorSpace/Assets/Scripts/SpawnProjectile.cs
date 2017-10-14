using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour {
	public GameObject Projectile;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			var mousePos = Input.mousePosition;
			Debug.Log (mousePos.y);
			if ((mousePos.y > 60)) {
				mousePos.z = 0.0f;       
				var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
				Instantiate (Projectile, objectPos, Quaternion.identity);
			}
		}
	}
} 