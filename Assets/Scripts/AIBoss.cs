using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour {
	
	private float x, z;
	//private Rigidbody boss;
	public bool isSkill;
    public bool isEnrage = false;
	public bool isBossDead = false;
	public Material enrageTex;
	private Collider skill1Trigger;
	private Animator anim;
    private Sword sword;
	private StageManager stage;
	private Rigidbody roshan;
    
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

	AudioSource mAudio;
	public AudioClip hajartanah, mati;

	// Use this for initialization
	void Start () {
		//boss = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		roshan = GetComponent<Rigidbody> ();
        sword = GameObject.Find("Sword").GetComponent<Sword>();
		stage = GameObject.Find ("Manager").GetComponent<StageManager> ();
        HPCurrent = HPTotal;
		mAudio = this.GetComponent<AudioSource> ();

		anim.SetBool ("isRun",true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (HPCurrent < 0 && !isBossDead) {
			isBossDead = true;
			anim.SetBool ("isDead", true);
			mAudio.PlayOneShot (mati);
			roshan.freezeRotation = false;
			GetComponent<BoxCollider> ().enabled = false;
			StartCoroutine ("delay");
		}
		
		if (!isBossDead) {
			if (HPCurrent / HPTotal < HPEnrage / 100 && !isEnrage)
				enrage ();
		
			if (GetComponentInChildren<Skill1Boss> ().isReady)
				skill1 ();
       	 
			if (!isSkill)
				moveToPlayer ();
			mAudio.Play();
		} else {
			HPCurrent = 0;
		}
	
	}

	void moveToPlayer(){
		Vector3 targetPos = new Vector3(target.position.x-transform.position.x, 0, target.position.z-transform.position.z);
		Quaternion toRot = Quaternion.LookRotation (targetPos);
		
		transform.rotation = Quaternion.RotateTowards (transform.rotation, toRot, turnSpeed * Time.deltaTime);


	}

	void skill1(){
		isSkill = true;
		anim.SetBool ("isSlam", true);
		mAudio.Stop();
		mAudio.PlayOneShot (hajartanah);
	}

	void skill1Shortcut(){
		GetComponentInChildren<Skill1Boss> ().skill1 (skill1Damage);
	}

    void enrage(){
        isEnrage = true;
		GetComponentInChildren<SkinnedMeshRenderer> ().material = enrageTex;
        //attack *= enrageMultiplier;
        armor *= enrageMultiplier;
        attackSpeed *= enrageMultiplier;
    }

    public void DamageCalculate(float Damage)
    {
		Debug.Log (HPCurrent);
        if(sword.isDamaging == true)
			HPCurrent -= Damage * ((100 - armor)/100);
    }

	IEnumerator delay(){
		yield return new WaitForSeconds(3);
		stage.GameOver ("YOU WIN");
	}
}
