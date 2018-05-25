using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;      
	private Vector3 offset;
	private float dis;
	private Vector3 playerPrevPos, playerMoveDir;

	void Start () 
	{
		transform.position = player.transform.position + new Vector3(0,5.5f,-7f);
		offset = player.transform.position - transform.position;

	}
		
	void LateUpdate () 
	{
		//transform.position = player.transform.position + offset;
		/*
		float angle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, angle, 0);

		transform.position = player.transform.position - (rotation*offset);
		transform.LookAt(player.transform);
		transform.rotation *= Quaternion.Euler(-20,0,0);
	

		float mouseX = Input.GetAxis("Mouse X");
		float rotAmountX = mouseX * turnSpeed;
		Vector3 playerRot = player.transform.rotation.eulerAngles;
		playerRot.y += rotAmountX;
		player.transform.rotation = Quaternion.Euler(playerRot);
		*/
	}
		
}