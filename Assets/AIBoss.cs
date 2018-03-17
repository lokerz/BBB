using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour {
	
	private float x, z;
	private Rigidbody boss;
	private bool isGrounded;

	public float speed;
	public float turnSpeed;
	//public float jumpForce;
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveToPlayer ();
	}

	void moveToPlayer(){
		/*
		Vector3 targetPos = new Vector3 (target.position.x, this.transform.position.y, target.position.z);
		transform.LookAt (finalPos);
		*/
		Vector3 targetPos = new Vector3(target.position.x-transform.position.x, 0, target.position.z-transform.position.z);
		Quaternion toRot = Quaternion.LookRotation (targetPos);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, turnSpeed * Time.deltaTime);

		transform.Translate(0, 0, Time.deltaTime * speed);
	}
}
