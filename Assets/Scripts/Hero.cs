using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float HPTotal;
    public float HPCurrent;
    public float attack;
    public float armor;
    public float critChance;

    private Claw claw;
    private Skill1Boss skill1;
    // Use this for initialization
    void Start () {
        claw = GameObject.Find("Claw").GetComponent<Claw>();
        skill1 = GameObject.Find("Roshan").GetComponent<Skill1Boss>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DamageCalculate(float Damage)
    {
        if (claw.isDamaging == true || skill1.heroBlasted == true)
            HPCurrent -= Damage * (100 - armor);
    }
}
