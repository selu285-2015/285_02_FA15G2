using UnityEngine;
using System.Collections;
//using TreeEditor;

public class TowerBase : MonoBehaviour
{
	
	public int Range;
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
			if (targetStack[i] != null && targetStack[i].GetInstanceID() == mob.GetInstanceID()) return;
		}
		targetStack[stackCount] = mob;
		stackCount++;
		if (stackCount == 100) stackCount = 0;
	}
	
	private GameObject StackPop()
	{
		GameObject mob = targetStack[newestTarget];
		targetStack[newestTarget] = null;
		newestTarget++;
		return mob;
	}
	
	void Update () {
		
		timer += Time.deltaTime;
		
		if(timer>=0.1) gunLine.enabled = false;
		
		if (CurrentTarget == null && targetStack[newestTarget] != null)
		{
			CurrentTarget = StackPop();
		}
		
		if (CurrentTarget != null && timer > FireRate)
		{
			Fire(CurrentTarget, Damage);
			timer = 0f;
		}
		
		if (CurrentTarget != null && Vector3.Distance(CurrentTarget.transform.position, self.gameObject.transform.position) > Range*3+1)
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
		
		if (trg.currentHP <= 0)
		{
			for (int i = 0; i < 50; i++)
			{
				if (TowerList[i] != null && TowerList[i].CurrentTarget == trg)
				{
					TowerList[i].CurrentTarget = null;
				}
			}
			CurrentTarget = null;
			Destroy(creep);
		}
		
	}
	
	
}