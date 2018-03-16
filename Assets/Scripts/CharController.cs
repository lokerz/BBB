using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private float x, z;
	private RaycastHit rayHit;
	private Ray ray;

	public float speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Movement ();
	}


	void Movement(){
		x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);
	}


}
