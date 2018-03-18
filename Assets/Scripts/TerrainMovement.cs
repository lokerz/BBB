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
	void LateUpdate () {

		if (boxSpringDown && !isDown) {
			if (transform.position.y <= tempHeight - 2) {
				boxSpringDown = false;
				boxSpringUp = true;
			}
			else
				transform.Translate (Vector3.up * Time.deltaTime * -5);
		}

		if (!boxSpringUp && transform.position.y > tempHeight && !isDown) {
			transform.Translate (Vector3.up * Time.deltaTime * -10);
			GetComponent<MeshRenderer> ().material.color = Color.white;
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

		if (isDown)
			transform.Translate (Vector3.up * Time.deltaTime * -1);

		if (isDown && transform.position.y < -10)
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
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Hero")
			timer = 0;
	}
}
