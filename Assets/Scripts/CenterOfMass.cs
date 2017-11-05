using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour {

	public Vector3 com;
	public Rigidbody2D rb;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.centerOfMass = com;
	}
}
