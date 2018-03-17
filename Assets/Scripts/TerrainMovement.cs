using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour {
	public float waitTime;
	public bool isDown = false;

	private float timer, tempHeight;
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
		if(!boxSpring && transform.position.y > tempHeight && !isDown)
			transform.Translate (Vector3.up * Time.deltaTime * -1);
		
		if (isDown)
			transform.Translate (Vector3.up * Time.deltaTime * -0.5f);

		if (isDown && transform.position.y < -10)
			Destroy (gameObject);

	}

	void OnTriggerStay(Collider other){
		hero = other.gameObject;
		if (other.tag == "Hero") {
			timer += Time.deltaTime;
		}
		if (timer >= waitTime) {
			timer = 0;
			boxUp (hero);
		}
	}

	void boxUp (GameObject hero){
		hero.GetComponent<Rigidbody> ().AddForce (hero.transform.up * 400, ForceMode.Impulse);
		boxSpring = true;
	}

	public void boxDown(){
		
	}


}
