using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Boss : MonoBehaviour {
	private bool skill1TriggerExpand = false;
	private bool heroBlasted = false;
	//public Animator anim;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (skill1TriggerExpand) {
			if (GetComponent<SphereCollider> ().radius <= 5)
				GetComponent<SphereCollider> ().radius += 1 * Time.deltaTime;
			else{
				skill1TriggerExpand = false;
				GetComponent<SphereCollider>().radius = 0.5f;
				GetComponent<SphereCollider> ().enabled = false;
				heroBlasted = false;
				gameObject.GetComponentInParent<Animator> ().SetBool ("isSlam", false);
				gameObject.GetComponentInParent<AIBoss> ().isSkill = false;
			}
		}
	}
	public void skill1(){
		//Ground Smash Attack
		gameObject.GetComponent<SphereCollider> ().enabled = true;
		GetComponent<SphereCollider> ().radius = 0.5f;
		skill1TriggerExpand = true;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor")
			other.GetComponent<TerrainMovement> ().boxUp ();
		if (other.tag == "Hero" && heroBlasted == false && other.GetComponent<CharController>().isGrounded) {
			heroBlasted = true;
			other.GetComponent<Rigidbody> ().AddForce (Vector3.up * 700, ForceMode.Impulse);
			other.GetComponent<Rigidbody> ().AddForce ((gameObject.transform.position - other.transform.position).normalized * -300, ForceMode.Impulse);
		}
	}
}
