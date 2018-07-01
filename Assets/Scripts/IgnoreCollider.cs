using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour {

	public Component[] colliders;

	void Start(){
		colliders = gameObject.GetComponentsInChildren<BoxCollider> ();
	}
    void OnCollisionEnter(Collision other)
    {
		if (other.gameObject.tag == "Hero")
			Physics.IgnoreCollision(other.collider,  gameObject.GetComponent<BoxCollider> ());
		
        if (other.gameObject.tag == "Tower")
			foreach (BoxCollider collider in colliders)
				Physics.IgnoreCollision(other.collider, collider);
    }
  
}
