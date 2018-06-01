using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private float x, z, rotY;
	private Rigidbody player;
	private float timer;
	public bool isGrounded = false;


	public float speed;
	public float turnSpeed;
	public float jumpForce;
	public GameObject skill1Bullet;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Movement
		x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);
		if (Input.GetAxis ("Horizontal")!= 0 | Input.GetAxis ("Vertical") != 0) {
			anim.SetBool ("isRun", true);
			anim.SetBool ("isIdle", false);
		} else {
			anim.SetBool ("isRun", false);
			anim.SetBool ("isIdle", true);
		}
		rotY = Input.GetAxis ("Mouse X");
		transform.Rotate (0, rotY*turnSpeed, 0);

		//Jump
		if (Input.GetKeyDown ("space") && isGrounded) {
			isGrounded = false;
			player.AddForce (transform.up * jumpForce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown ("1")) {
			Vector3 bulletpos = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 2);
			Instantiate (skill1Bullet, bulletpos, Quaternion.identity);
		}

		if (Input.GetMouseButtonDown (0)) {
			//anim.SetBool ("isAttack",true);
			anim.SetTrigger("Attack");
		}
		//Debug.Log (isGrounded);
	}
	/*
	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}

	void OnColliderExit(Collider other){
		if(other.tag == "Floor")
			isGrounded = false;
	}
	*/
	public void ResetAttack(){
		anim.SetBool ("isAttack", false);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor")
			isGrounded = true;
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Floor")
			isGrounded = true;
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Floor")
			isGrounded = false;
	}


}
