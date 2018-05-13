using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    public float Attack;
    public float waitTime;
    public bool isDamaging = true;
    private AIBoss roshan;

    void Start()
    {
        Attack = GameObject.Find("HeroCube").GetComponent<Hero>().attack;
        roshan = GameObject.Find("Roshan").GetComponent<AIBoss>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(isDamaging == true & other.tag == "HitBox")
        {
            roshan.DamageCalculate(Attack);
            isDamaging = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (isDamaging == false & other.tag == "HitBox")
        {
            StartCoroutine(DamageOn());
        }
    }

    IEnumerator DamageOn()
    {
        yield return new WaitForSeconds(waitTime);
        isDamaging = true;
    }
}
