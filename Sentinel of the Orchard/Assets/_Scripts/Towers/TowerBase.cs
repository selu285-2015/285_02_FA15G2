using UnityEngine;
using System.Collections;
//using TreeEditor;

public class TowerBase : MonoBehaviour
{
	
	public float Range;
	public int Damage;
	public float FireRate;
	
	private GameObject CurrentTarget = null;
	private float timer = 5f;
	private GameObject[] targetStack = new GameObject[100];
	private int stackCount = 0;
	private int newestTarget = 0;
	private TowerBase self;
	private Ray shootRay;
	private LineRenderer gunLine;
	
	private static TowerBase[] TowerList = new TowerBase[50];
	private static int towerCount = 0;
	EnemyHealth targ;
	
	void Awake()
	{
		self = GetComponent<TowerBase>();
		gunLine = GetComponent<LineRenderer>();
		GetComponent<SphereCollider>().radius = Range;
		TowerList[towerCount] = self;
		towerCount++;
	}
	
	private void StackPush(GameObject mob)
	{
		for (int i = 0; i < 100; i++)
		{
			if (targetStack[i] != null && targetStack[i].GetInstanceID() == mob.GetInstanceID()) return; // Checks if the target being added is already in the list
		}
		targetStack[stackCount] = mob;
		stackCount++;
		if (stackCount == 100) stackCount = 0;
	}
	
	private GameObject StackPop()
	{
	    if (targetStack[newestTarget] != null)  // If the next slot contains an enemy, make it the current target and remove it from the list.
	    {
	        GameObject mob = targetStack[newestTarget];
	        if (mob == null) // This looks redundant, but it isn't. == is overloaded in unity to check if a mob has been destroyed when checked against null.
	        {
	            mob = null;
	        }
	        targetStack[newestTarget] = null;
	        newestTarget++;
	        if (newestTarget == 100) newestTarget = 0;
	        return mob;
	    }
	    else                                    // If the next slot is empty, run through the list to check for an enemy
	    {
	        int counter = newestTarget;
	        for (int i = 0; i < 100; i++)
	        {
	            if (targetStack[counter] != null)
	            {
	                newestTarget = counter;
	                break;
	            }
	            counter++;
	            if (counter == 100) counter = 0;
	        }
	        return null;
	    }
	}
	
	void Update () {
		
		timer += Time.deltaTime;

        self.gameObject.transform.position = new Vector3(self.gameObject.transform.position.x, 6.45f, self.gameObject.transform.position.z);

        if (timer>=0.1) gunLine.enabled = false;

	    if (CurrentTarget != null && CurrentTarget.GetComponent<EnemyHealth>().currentHP <= 0)
        {
            CurrentTarget = null; // If target enemy is dead, untarget it
        }
            
		if (CurrentTarget == null)
		{
			CurrentTarget = StackPop();
		}
		
		if (CurrentTarget != null && timer > FireRate)
		{
			Fire(CurrentTarget, Damage);
			timer = 0f;
		}
		
		if (CurrentTarget != null && Vector3.Distance(CurrentTarget.transform.position, self.gameObject.transform.position) > Range*3f+1f) // If target is out of range, untarget it
		{
			CurrentTarget = null;
		}
		
		
	}
	
	void OnTriggerEnter(Collider mob)
	{
		if (mob.gameObject.CompareTag("Creep"))
		{
			StackPush(mob.gameObject);
		}
	}
	
	void OnTriggerExit(Collider mob)
	{
		if (mob.gameObject.CompareTag("Creep") && CurrentTarget == mob.gameObject)
		{
			CurrentTarget = null;
		}
	}
	
	
	void Fire(GameObject creep, int damage)
	{
		EnemyHealth trg = creep.GetComponent<EnemyHealth>();
		trg.TakeDMG(damage, Vector3.back);
		
		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);
		shootRay.origin = transform.position;
		shootRay.direction = transform.position - creep.transform.position;
		gunLine.SetPosition(1, shootRay.origin - shootRay.direction * Vector3.Distance(CurrentTarget.transform.position, self.gameObject.transform.position) * 1f);
	}

    public void ClearTarget(EnemyHealth target) // Removes a defeated enemy from all towers target lists.
    {
        for (int i = 0; i < 50; i++)
        {
            if (TowerList[i] != null && TowerList[i].CurrentTarget == target.gameObject)
            {
                TowerList[i].CurrentTarget = null;
            }
        }
        CurrentTarget = null;
    }
	
	
}