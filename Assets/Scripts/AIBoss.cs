using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour {
	
	private float x, z;
	private Rigidbody boss;
	private bool isGrounded;

	private Collider skill1Trigger;


	public float speed;
	public float turnSpeed;
	public float jumpForce;
	public Transform target;

	// Use this for initialization
	void Start () {
		boss = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveToPlayer ();

		if (Input.GetKeyDown ("f1")) {
			boss.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			Invoke("skill1",0.7f);
			//skill1();
		}

	
	}

	void moveToPlayer(){
		Vector3 targetPos = new Vector3(target.position.x-transform.position.x, 0, target.position.z-transform.position.z);
		Quaternion toRot = Quaternion.LookRotation (targetPos);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, turnSpeed * Time.deltaTime);

		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}

	void skill1(){
		GetComponentInChildren<Skill1Boss> ().skill1 ();
	}
}
