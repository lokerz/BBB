using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    public float AttackMin;
	public float AttackMax;
    public float waitTime;
    public bool isDamaging = false;
    private AIBoss roshan;
	private Animator anim;
	private float Attack;

    void Start()
    {
		anim = GetComponentInParent<Animator> ();	
		roshan = GameObject.Find("Roshan").GetComponent<AIBoss>();
    }
		

    void OnTriggerEnter(Collider other)
    {
		if(isDamaging == true && (other.tag == "HitBox" || other.tag == "Claw"))
        {
			
			Attack = Random.Range (AttackMin, AttackMax);
            roshan.DamageCalculate(Attack);
			isDamaging = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
		
    }
}
