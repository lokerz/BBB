using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour {
	private float timer, tempHeight;
	public float waitTime;
	private bool boxSpring = false;
	private GameObject hero;
	// Use this for initialization
	void Start () {
		tempHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (boxSpring) {
			transform.Translate (Vector3.up * Time.deltaTime * 20);
			if (transform.position.y >= 3)
				boxSpring = false;
		}
		if(!boxSpring && transform.position.y > tempHeight)
			transform.Translate (Vector3.up * Time.deltaTime * -1);
	}

	void OnTriggerStay(Collider other){
		hero = other.gameObject;
		if (other.tag == "Hero") {
			timer += Time.deltaTime;
			Debug.Log (timer);
		}
		if (timer >= waitTime) {
			Debug.Log ("jump");
			timer = 0;

			boxUp (hero);
			boxDown ();

		}
	}
	void boxUp (GameObject hero){
		hero.GetComponent<Rigidbody> ().AddForce (hero.transform.up * 750);
		boxSpring = true;
	}
	void boxDown(){
		
	}
}
