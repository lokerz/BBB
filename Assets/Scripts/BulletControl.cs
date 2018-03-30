﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 50, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(GameObject.Find("Boss").GetComponent<Transform>());
		transform.Translate(0, 0, Time.deltaTime * 25);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag != "Hero")
			Destroy (gameObject);
	}
}
