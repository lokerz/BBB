using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	private float x, z, rotY;
	private Rigidbody player;
	private float timer;
	public bool isGrounded = false;
	public bool isDead = false;
	public bool isAttackReady = true;

	public float speed;
	public float turnSpeed;
	public float jumpForce;
	private Animator anim;
	private StageManager stage;
	private Sword sword;
	private AIBoss roshan;

	private AudioSource mAudio, mAudio2;
	public AudioClip Walk, Jump;
	public AudioClip[] Attack;
	public bool isRunning = false, isJumping = false, isLanding = false, isAttacking = false;
	private int n;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GetComponent<Rigidbody> ();
		sword = GameObject.Find ("Sword").GetComponent<Sword> ();
		stage = GameObject.Find ("Manager").GetComponent<StageManager> ();
		roshan = GameObject.Find ("Roshan").GetComponent<AIBoss> ();
		mAudio = this.GetComponent<AudioSource> ();
		mAudio.clip = Walk; mAudio.loop = true; mAudio.playOnAwake = false;
		mAudio2 = gameObject.AddComponent<AudioSource> ();
		mAudio2.loop = false; mAudio.playOnAwake = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Movement
	
		x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
		transform.Translate(x, 0, z);

		if (Input.GetAxis ("Horizontal")!= 0 || Input.GetAxis ("Vertical") != 0) {
            anim.SetBool("isRun", true);
            anim.SetBool("isIdle", false);
			isRunning = true;
            if (Input.GetAxis("Horizontal") > 0)
            {
                anim.SetBool("runRight", true);
                anim.SetBool("runLeft", false);
                anim.SetBool("runFront", false);
                anim.SetBool("runBack", false);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("runRight", false);
                anim.SetBool("runLeft", true);
                anim.SetBool("runFront", false);
                anim.SetBool("runBack", false);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                anim.SetBool("runRight", false);
                anim.SetBool("runLeft", false);
                anim.SetBool("runFront", true);
                anim.SetBool("runBack", false);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                anim.SetBool("runRight", false);
                anim.SetBool("runLeft", false);
                anim.SetBool("runFront", false);
                anim.SetBool("runBack", true);
            }


        }
        else {
			anim.SetBool ("isRun", false);
			isRunning = false;
			anim.SetBool ("isIdle", true);
            anim.SetBool("runRight", false);
            anim.SetBool("runLeft", false);
            anim.SetBool("runFront", false);
            anim.SetBool("runBack", false);
        }
		rotY = Input.GetAxis ("Mouse X");
		transform.Rotate (0, rotY*turnSpeed, 0);
					//Jump
		if (Input.GetKeyDown ("space") && isGrounded) {
			isGrounded = false;
			isJumping = true;
			player.AddForce (transform.up * jumpForce, ForceMode.Impulse);
		}
			
		if (Input.GetMouseButtonDown (0) && isAttackReady) {
			isAttackReady = false;
			sword.isDamaging = true;
			anim.SetTrigger("Attack");
			isAttacking = true;
		}

		if (transform.position.x > 60 || transform.position.x < -60 || transform.position.y < -15 || transform.position.z > 60 ||transform.position.z < -60) {
			isDead = true;
			stage.GameOver ("YOU LOSE");
		}

	}
	/*
	void OnCollisionEnter(Collision other){
		if(other.collider.tag == "Floor")
			isGrounded = true;
	}

	void OnColliderExit(Collider other){
		if(other.tag == "Floor")
			isGrounded = false;
	}
	*/

	void Update(){
		if (isGrounded && isRunning){
			if (mAudio.isPlaying){
				//do nothing
			}
			else{
				mAudio.clip = Walk;
				mAudio.loop = true;
				mAudio.Play();
				//Debug.Log("We're walking!!!");
			}
		}
		else{
			mAudio.Stop();
		}
		//sfx
		if (isJumping){
			mAudio2.PlayOneShot(Jump);
			isJumping = false;
			isLanding = false;
		}
		if (isAttacking) {
			mAudio2.PlayOneShot (Attack [n]);
			if (n == Attack.Length - 1) {
				n = 0;
			} else {
				n++;
			}
			isAttacking = false;
		}
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Floor")
			isGrounded = true;
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Floor")
			isGrounded = true;
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Floor")
			isGrounded = false;
	}

	public void resetAttack(){
		isAttackReady = true;
	}

}
