using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour {
	
	private float x, z;
	//private Rigidbody boss;
	public bool isSkill;
    public bool isEnrage;

	private Collider skill1Trigger;
	private Animator anim;
    private Sword sword;
    
    public float HPTotal;
    public float HPCurrent;
    public float HPEnrage;
    public float attack;
    public float armor;
	public float attackSpeed;
    public float enrageMultiplier;
    public float skill1Damage;

    public float turnSpeed;
    public Transform target;

	// Use this for initialization
	void Start () {
		//boss = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
        sword = GameObject.Find("Sword").GetComponent<Sword>();
        HPCurrent = HPTotal;


		anim.SetBool ("isRun",true);
		//InvokeRepeating ("skill1", 10, 30);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //HPCurrent -= 0.1f;
        
        if (HPCurrent / HPTotal < HPEnrage / 100 && !isEnrage)
            enrage();

        //Debug.Log(Vector3.Distance(transform.position, target.position));
        if (Vector3.Distance(transform.position, target.position) > 20)
            if(GetComponentInChildren<Skill1Boss>().isReady)
                  skill1();
        
        	
		if(!isSkill)
			moveToPlayer ();
	
	}

	void moveToPlayer(){
		Vector3 targetPos = new Vector3(target.position.x-transform.position.x, 0, target.position.z-transform.position.z);
		Quaternion toRot = Quaternion.LookRotation (targetPos);
		
		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, turnSpeed * Time.deltaTime);


	}

	void skill1(){
		isSkill = true;
		anim.SetBool ("isSlam", true);
	}

	void skill1Shortcut(){
		GetComponentInChildren<Skill1Boss> ().skill1 (skill1Damage);
	}

    void enrage(){
        isEnrage = true;
        attack *= enrageMultiplier;
        armor *= enrageMultiplier;
        attackSpeed *= enrageMultiplier;
    }

    public void DamageCalculate(float Damage)
    {
        if(sword.isDamaging == true)
            HPCurrent -= Damage * (100 - armor);
    }
}
