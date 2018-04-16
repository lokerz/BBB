﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private float x, z;
	private Rigidbody player;
	private float timer;
	public bool isGrounded = false;


	public float speed;
	public float jumpForce;
	public GameObject skill1Bullet;


	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Movement
		x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);

		//Jump
		if (Input.GetKeyDown ("space") && isGrounded) {
			isGrounded = false;
			player.AddForce (transform.up * jumpForce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown ("1")) {
			Vector3 bulletpos = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);
			Instantiate (skill1Bullet, bulletpos, Quaternion.identity);
		}

		//Debug.Log (isGrounded);
	}
	/*
	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}

	void OnColliderExit(Collider other){
		if(other.tag == "Floor")
			isGrounded = false;
	}
	*/
	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor")
			isGrounded = true;
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Floor")
			isGrounded = true;
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Floor")
			isGrounded = false;
	}


}
