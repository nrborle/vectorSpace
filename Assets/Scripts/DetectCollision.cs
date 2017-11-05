using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//checking for collision
	void OnCollisionEnter2D (Collision2D col){
		
		//Check collision name
		//Debug.Log("collision tag = " + col.gameObject.tag);
		if(col.gameObject.tag == "Gravity"){
			DestroyAllProjectiles ();
		}
	}

	//Detects all items which are projectiles, keeps an array of them, and destroys them all at once when one collides with the gravity object.
	void DestroyAllProjectiles(){
		GameObject[] projectiles = GameObject.FindGameObjectsWithTag ("Projectile");
		foreach (GameObject proj in projectiles)
			GameObject.Destroy (proj);
	}
}
