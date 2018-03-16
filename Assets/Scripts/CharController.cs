using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private float x, z;
	private RaycastHit rayHit;
	private Ray ray;

	public float speed;
	public float turnSpeed;

	// Use this for initialization
	void Start () {
		HideCursor ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Look ();
		Movement ();
	}

	void HideCursor(){
		Cursor.visible = false;
	}
	void Movement(){
		x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);
	}

	void Look(){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray, out rayHit, 100)) {
			transform.LookAt(new Vector3 (rayHit.point.x, transform.position.y, rayHit.point.z));
		}
	}

}
