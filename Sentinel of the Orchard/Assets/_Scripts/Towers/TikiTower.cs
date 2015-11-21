using UnityEngine;
using System.Collections;

public class TikiTower : TowerBase
{
	
    private float timer = 5f;
    private GameObject[] targetStack = new GameObject[100];
    private int stackCount = 0;
    private int newestTarget = 0;
    private TikiTower self;
    EnemyHealth targ;

    void Awake()
    {
        self = GetComponent<TikiTower>();
        GetComponent<SphereCollider>().radius = Range;
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

    void Update()
    {

        timer += Time.deltaTime;
        self.gameObject.transform.position = new Vector3(self.gameObject.transform.position.x, 1.2f, self.gameObject.transform.position.z);
        if (timer >= FireRate)
        {
            Fire(Damage);
            timer = 0;
        }

    }

    void OnTriggerEnter(Collider mob)
    {
        if (mob.gameObject.CompareTag("Creep"))
        {
            for (int i = 0; i < 100; i++)
            {
                if (targetStack[i] != null && targetStack[i].GetInstanceID() == mob.GetInstanceID()) return;
            }
            StackPush(mob.gameObject);
        }
    }

/*    void OnTriggerExit(Collider mob)
    {
        if (mob.gameObject.CompareTag("Creep"))
        {
            for (int i = 0; i < 100; i++)
            {
                if (targetStack[i] != null && targetStack[i].GetInstanceID() == mob.GetInstanceID()) targetStack[i] = null;
            }
        }
    }
*/

    void Fire(int damage)
    {

        for (int i = 0; i < 100; i++)
        {
            if (targetStack[i] != null)
            {
                int distance = (int) Mathf.Floor((int)Vector3.Distance(targetStack[i].gameObject.transform.position, self.gameObject.transform.position));
                if (distance >= (Range+1))
                {
                    targetStack[i] = null;
                    continue;
                }
                EnemyHealth trg = targetStack[i].GetComponent<EnemyHealth>();
                trg.TakeDMG(damage, Vector3.back);
            }
        }
    }

}