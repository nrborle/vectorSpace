using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandBoxCollision : MonoBehaviour {

	//checking for collision
	void OnCollisionEnter2D (Collision2D col){
		Destroy (this.gameObject);
	}
		
}
