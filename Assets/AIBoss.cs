using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour {
	
	private float x, z, temp1, temp2;
	private Rigidbody boss;
	private bool isGrounded;

	private Collider skill1Trigger;
	private bool skill1TriggerExpand = false;
	private bool heroJumped = false;

	public float speed;
	public float turnSpeed;
	public float jumpForce;
	public Transform target;

	// Use this for initialization
	void Start () {
		boss = GetComponent<Rigidbody> ();
		temp1 = speed;
		temp2 = turnSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveToPlayer ();

		if (Input.GetKeyDown ("1")) {
			boss.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			Invoke("skill1",0.7f);
			//skill1();
		}

		if (skill1TriggerExpand) {
			if (GetComponent<SphereCollider> ().radius <= 5)
				GetComponent<SphereCollider> ().radius += 1f * Time.deltaTime;
			else{
				skill1TriggerExpand = false;
				GetComponent<SphereCollider>().radius = 0.5f;
				GetComponent<SphereCollider> ().enabled = false;
				heroJumped = false;
				speed = temp1;
				turnSpeed = temp2;
			}
		}
	}

	void moveToPlayer(){
		Vector3 targetPos = new Vector3(target.position.x-transform.position.x, 0, target.position.z-transform.position.z);
		Quaternion toRot = Quaternion.LookRotation (targetPos);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, turnSpeed * Time.deltaTime);

		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void skill1(){
		//Ground Smash Attack
		if (isGrounded) {
			gameObject.GetComponent<SphereCollider> ().enabled = true;
			GetComponent<SphereCollider> ().radius = 0.5f;
			skill1TriggerExpand = true;

			speed = 0;
			turnSpeed = 0;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor")
			other.GetComponent<TerrainMovement> ().boxUp ();
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}
		
}
