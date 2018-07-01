using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Boss : MonoBehaviour {
	private bool skill1TriggerExpand = false;
    //private float damage;
    public bool heroBlasted = false;
    public bool isReady = true;
    public int cooldownTime;

	// Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        
		if (skill1TriggerExpand) {
			if (GetComponent<SphereCollider> ().radius <= 5)
				GetComponent<SphereCollider> ().radius += 1 * Time.deltaTime;
			else{
				skill1TriggerExpand = false;
				GetComponent<SphereCollider>().radius = 0.5f;
				GetComponent<SphereCollider> ().enabled = false;
				heroBlasted = false;
				gameObject.GetComponentInParent<Animator> ().SetBool ("isSlam", false);
				gameObject.GetComponentInParent<AIBoss> ().isSkill = false;
			}
		}
	}
	public void skill1(float attack){
        //Ground Smash Attack
        if (isReady)
        {
            isReady = false;
            StartCoroutine("Cooldown");
            gameObject.GetComponent<SphereCollider>().enabled = true;
            GetComponent<SphereCollider>().radius = 0.5f;
            skill1TriggerExpand = true;
        }
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor" || other.tag == "Tower")
			other.GetComponent<TerrainMovement> ().boxUp ();
		if (other.tag == "Hero" && heroBlasted == false && other.transform.position.y < 3) {
			heroBlasted = true;
            //hero.DamageCalculate(damage);
			other.GetComponent<Rigidbody> ().AddForce (Vector3.up * 1200, ForceMode.Impulse);
			other.GetComponent<Rigidbody> ().AddForce ((gameObject.transform.position - other.transform.position).normalized * -1200, ForceMode.Impulse);
		}
	}

    IEnumerator Cooldown(){
        yield return new WaitForSeconds(cooldownTime);
        isReady = true;
    }
}
