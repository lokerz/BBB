using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour {
	
	private float x, z;
	private Rigidbody boss;
	private bool isGrounded;
	public bool isSkill;

	private Collider skill1Trigger;
	private Animator anim;

	public float speed;
	public float turnSpeed;
	public float jumpForce;
	public Transform target;

	// Use this for initialization
	void Start () {
		boss = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		anim.SetBool ("isRun",true);
		InvokeRepeating ("skill1", 10, 30);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			
		if(!isSkill)
			moveToPlayer ();
	
	}

	void moveToPlayer(){
		Vector3 targetPos = new Vector3(target.position.x-transform.position.x, 0, target.position.z-transform.position.z);
		Quaternion toRot = Quaternion.LookRotation (targetPos);
		//toRot = Quaternion.Euler (0, toRot.y, 0);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, turnSpeed * Time.deltaTime);


	}

	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}

	void jump(){
		boss.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}
		
	void skill1(){
		isSkill = true;
		anim.SetBool ("isSlam", true);
	}

	void skill1s(){
		GetComponentInChildren<Skill1Boss> ().skill1 ();
	}

}
