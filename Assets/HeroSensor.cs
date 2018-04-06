﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSensor : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Hero") {
			GetComponentInParent<Animator> ().SetBool ("isRun", false);
			GetComponentInParent<Animator> ().SetBool ("isIdle", true);
		}
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Hero") {
			GetComponentInParent<Animator> ().SetBool ("isRun", false);
			GetComponentInParent<Animator> ().SetBool ("isIdle", true);
			//GetComponentInParent<Animator> ().SetBool ("isAttack1", true);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Hero") {
			//GetComponentInParent<Animator>().SetBool ("isAttack1", false);
			GetComponentInParent<Animator> ().SetBool ("isIdle", false);
			GetComponentInParent<Animator> ().SetBool ("isRun", true);
		}
	}


}
