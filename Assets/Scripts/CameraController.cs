using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;      
	private Vector3 offset;
	public float turnSpeed;

	void Start () 
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		transform.position = player.transform.position + new Vector3(0,2f,-5.5f);
		offset = player.transform.position - transform.position;
	
	}
		
	void LateUpdate () 
	{
		
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
	}
		
}