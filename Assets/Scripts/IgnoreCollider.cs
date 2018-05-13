using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Floor")
           Physics.IgnoreCollision( other.collider, gameObject.GetComponent<BoxCollider>());
    }
  
}
