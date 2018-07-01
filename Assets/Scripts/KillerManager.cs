using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerManager : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Floor" || other.tag == "Tower" )
			Destroy(other.gameObject);
	}
}
