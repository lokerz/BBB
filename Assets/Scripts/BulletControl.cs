using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 50, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 bossPos = new Vector3 (GameObject.Find ("Roshan").GetComponent<Transform> ().position.x, 10, GameObject.Find("Roshan").GetComponent<Transform>().position.z);
		transform.LookAt(bossPos);
		transform.Translate(0, 0, Time.deltaTime * 25);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag != "Hero")
			Destroy (gameObject);
	}
}
