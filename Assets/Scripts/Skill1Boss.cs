using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Boss : MonoBehaviour {
	private float temp1, temp2;
	private bool skill1TriggerExpand = false;
	private bool heroJumped = false;
	//public Animator anim;
	// Use this for initialization
	void Start () {
		temp1 = GetComponentInParent<AIBoss>().speed;
		temp2 = GetComponentInParent<AIBoss>().turnSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (skill1TriggerExpand) {
			if (GetComponent<SphereCollider> ().radius <= 5)
				GetComponent<SphereCollider> ().radius += 1 * Time.deltaTime;
			else{
				skill1TriggerExpand = false;
				GetComponent<SphereCollider>().radius = 0.5f;
				GetComponent<SphereCollider> ().enabled = false;
				heroJumped = false;
				gameObject.GetComponentInParent<Animator> ().SetBool ("isSlam", false);
				GetComponentInParent<AIBoss>().speed = temp1;
				GetComponentInParent<AIBoss>().turnSpeed = temp2;
			}
		}
	}
	public void skill1(){
		//Ground Smash Attack
		gameObject.GetComponent<SphereCollider> ().enabled = true;
		GetComponent<SphereCollider> ().radius = 0.5f;
		GetComponentInParent<AIBoss>().speed = 0;
		GetComponentInParent<AIBoss>().turnSpeed = 0;

		skill1TriggerExpand = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor")
			other.GetComponent<TerrainMovement> ().boxUp ();
		if (other.tag == "Hero" && heroJumped == false && other.GetComponent<CharController>().isGrounded) {
			heroJumped = true;
			other.GetComponent<Rigidbody> ().AddForce (Vector3.up * 700, ForceMode.Impulse);
			other.GetComponent<Rigidbody> ().AddForce (Vector3.back * 300, ForceMode.Impulse);
		}
	}
}
