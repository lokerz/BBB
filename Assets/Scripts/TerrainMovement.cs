using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour {
	public float trapJumpTime;
	public bool isDown = false;

	private float timer, tempHeight;
	private bool boxSpringDown = false;
	private bool boxSpringUp = false;
	private Rigidbody hero;


	// Use this for initialization
	void Start () {
		tempHeight = transform.position.y;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (boxSpringDown && !isDown) {
			if (transform.position.y <= tempHeight - 2) {
				boxSpringDown = false;
				boxSpringUp = true;
			}
			else
				transform.Translate (Vector3.up * Time.deltaTime * -10);
		}
		if (boxSpringUp && !isDown) {
			if (transform.position.y >= tempHeight + 2) {
				boxSpringUp = false;
			}
			else{
				transform.Translate (Vector3.up * Time.deltaTime * 10);
				GetComponent<MeshRenderer> ().material.color = Color.red;
			}
		}

		if (!boxSpringUp && transform.position.y > tempHeight && !isDown) {
			transform.Translate (Vector3.up * Time.deltaTime * -5);
			GetComponent<MeshRenderer> ().material.color = Color.white;
		}

		if (isDown)
			transform.Translate (Vector3.up * Time.deltaTime * -1);

		if (isDown && transform.position.y < tempHeight-30)
			Destroy (gameObject);

	}
		
	public void boxUp(){
		boxSpringDown = true;
	}

	void OnTriggerStay(Collider other){
		if(other.tag == "Hero")
			timer += Time.deltaTime;
		if (timer >= trapJumpTime) {
			timer = 0;
			boxUp ();
			trapUp (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Hero")
			timer = 0;
	}

	void trapUp (GameObject other){
		if (other.tag == "Hero")
			other.GetComponent<Rigidbody> ().AddForce (Vector3.up * 2000, ForceMode.Impulse);
	}
}
