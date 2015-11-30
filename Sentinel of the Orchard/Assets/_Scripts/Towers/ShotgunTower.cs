using UnityEngine;
using System.Collections;

public class ShotgunTower : TowerBase {
    
    
    private float timer = 5f;
    private GameObject[] targetStack = new GameObject[100];
    private int stackCount = 0;
    private int newestTarget = 0;
    private TowerBase self;
    private Ray shootRay;
    private LineRenderer gunLine;
    int shootableMask;

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
        shootableMask = LayerMask.GetMask("Shootable");
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

        self.gameObject.transform.position = new Vector3(self.gameObject.transform.position.x, 6.45f, self.gameObject.transform.position.z);

        if (timer >= 0.1) gunLine.enabled = false;

        if (CurrentTarget != null && CurrentTarget.GetComponent<EnemyHealth>().currentHP <= 0)
        {
            CurrentTarget = null; // If target enemy is dead, untarget it
        }

        if (CurrentTarget == null)
        {
            CurrentTarget = StackPop();
        }

        if (CurrentTarget != null && timer > FireRate - FireRateLevel * 0.1)
        {
            Fire(CurrentTarget, Damage + DamageLevel * 10);
            timer = 0f;
        }

        if (CurrentTarget != null && Vector3.Distance(CurrentTarget.transform.position, self.gameObject.transform.position) > Range * 3f + 1f) // If target is out of range, untarget it
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

        Transform trf = transform; // a little optimization
        RaycastHit hit;
        Transform cam = Camera.main.transform;
        Ray ray = new Ray(creep.transform.position, creep.transform.position - self.gameObject.transform.position);
        Ray tempRay;
        for (int i = 0; i < 10; i++){
            Vector3 f = transform.forward;

            f.x += Random.Range(-1, 1);
            f.y += Random.Range(-1, 1);
            f.z += Random.Range(-1, 1);
            tempRay = ray;
            tempRay.direction += f;
            if (Physics.Raycast(tempRay, out hit, Range, shootableMask))
            {

                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                LineRenderer line = gunLine;
              //  gunLine.SetPosition(0, transform.position);
                tempRay.origin = transform.position;
            //    gunLine.SetPosition(1, tempRay.origin - tempRay.direction * Vector3.Distance(enemyHealth.gameObject.transform.position, self.gameObject.transform.position) * 1f);
                
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDMG(damage, hit.point);
                }
            }
        }

        
    }
    


}