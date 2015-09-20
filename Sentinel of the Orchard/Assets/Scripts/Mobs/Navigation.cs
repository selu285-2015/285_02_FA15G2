using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

		
	public bool isRIP = true;

		Transform nexus;               
		NavMeshAgent nav;               
		
		
		void Awake ()
		{
	
			nexus = GameObject.FindGameObjectWithTag ("nexus").transform;
			isRIP = false;
			nav = GetComponent <NavMeshAgent> ();
		}
		
	void OnTriggerEnter(Collider checker)
	{	
		
		if (checker.gameObject == nexus) 
		{
			print ("I should stop lel");
		
		}
	}
		
		void Update (){

			if(isRIP = true){
			print ("alive");
				nav.SetDestination (nexus.position);
		}

	}
}
