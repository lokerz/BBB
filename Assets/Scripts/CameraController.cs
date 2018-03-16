﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		transform.position = player.transform.position + new Vector3(0,1.5f,-2.5f);
		//gameObject.transform.position = player.transform.position + new Vector3(0,1.1f,0.2f);
		offset = player.transform.position - transform.position;
	
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		float angle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, angle, 0);

		transform.position = player.transform.position - (rotation*offset) + new Vector3(0,1f,0);
		transform.LookAt(player.transform);
		transform.rotation *= Quaternion.Euler(-20,0,0);
	}
}