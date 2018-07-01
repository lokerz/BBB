using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	public GameObject menuCanvas;
	public GameObject playCanvas;
	public GameObject overCanvas;
	public GameObject DontDestroy;



	public void play(){
		menuCanvas.SetActive (false);
		playCanvas.SetActive (true);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1;

	}

	public void playAgain(){
		DontDestroyOnLoad (GetComponent<AudioSource>());
		SceneManager.LoadScene ("gameplay");

	}

	public void GameOver(string textA){
		if(textA == "YOU LOSE")
			Time.timeScale = 0;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		playCanvas.SetActive (false);
		overCanvas.SetActive (true);
		GameObject.Find ("WinLose").GetComponent<Text> ().text = textA;
	}
}
