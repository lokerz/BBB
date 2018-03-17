using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private float x, z;
	private Rigidbody player;
	private bool isGrounded;

	public float speed;
	public float jumpForce;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Movement
		x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);

		//Jump
		if (Input.GetKeyDown ("space") && isGrounded) {
			player.AddForce (transform.up * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
	}
		
	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}

}
