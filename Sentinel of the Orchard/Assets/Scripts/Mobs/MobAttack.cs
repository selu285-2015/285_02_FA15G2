using UnityEngine;
using System.Collections;

public class MobAttack : MonoBehaviour {

	public float attackSpeed = 1;
	public int attackDMG = 10;

	GameObject nexus;
	NexusHP nexusHP;
	//import the enemys health script here
	bool canHit;
	float timer;

	// Use this for initialization
	void Start () {
		nexus = GameObject.FindGameObjectWithTag ("nexus");
		nexusHP = nexus.GetComponent<NexusHP>();
		//import enemy health class getcomponet<enemyHP>
		print ("start");
	}

	void OnTriggerEnter(Collider checker)
	{	
	
		if (checker.gameObject == nexus) 
		{
			print ("enter");
			canHit = true;
		}
	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= attackSpeed && canHit)
		{
			Attack();
		}
	}

	void Attack()
	{
		timer = 0f;

		nexusHP.TakeDamage (attackDMG);
	}
}
