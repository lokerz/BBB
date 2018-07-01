using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUpdate : MonoBehaviour {
	private AIBoss roshan;
	private float temp;
	// Use this for initialization
	void Start () {
		temp = GetComponent<RectTransform> ().localScale.x;
		roshan = GameObject.Find("Roshan").GetComponent<AIBoss>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(roshan.HPCurrent > 0)
			GetComponent<RectTransform> ().localScale = new Vector3 ((roshan.HPCurrent / roshan.HPTotal) * 13, 0.5f, 1);
		else
			GetComponent<RectTransform> ().localScale = new Vector3 (0, 0.5f, 1);
	}
}
