using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
	public GameObject menuCanvas;

	public void play(){
		
		menuCanvas.SetActive (false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;

	}
}
