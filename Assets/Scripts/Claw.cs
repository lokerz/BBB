using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour {
	private bool isClawed = false;
	public GameObject roshan;
	void OnTriggerEnter(Collider other){
		
		if (other.tag == "Claw") {
			Debug.Log ("clawed");
			if (!isClawed) {
				isClawed = true;
				GetComponent<Rigidbody> ().AddForce (Vector3.up * 1000, ForceMode.Impulse);
				GetComponent<Rigidbody> ().AddForce ((roshan.transform.position - transform.position).normalized * -750, ForceMode.Impulse);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Claw")
			isClawed = false;
	}
}
