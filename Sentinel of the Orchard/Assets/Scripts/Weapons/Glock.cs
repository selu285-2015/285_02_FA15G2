using UnityEngine;
using System.Collections;

public class Glock : MonoBehaviour{
	
	public int dmg;
	public float  attackSpeed = .5f;
	public float range = 100f;


	
	float timer= 0 ;
	Ray shotCheck;
	int shootableMask;
	RaycastHit shot;
	Light gunLight;
	public Transform prefab;
	//AudioSource gunShot;


	void Start () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLight = GetComponent <Light> ();

	}
	
	// Update is called once per frame

	void Update () {
		timer += Time.deltaTime;
		shotCheck = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));
		//print (timer);

		if((Input.GetMouseButtonDown(0)) && (timer <= attackSpeed)) {// If someone has any idea of why this works backwards please let me know.
			Shoot ();
			print("hai");
		}
		if(Input.GetMouseButtonDown(1)){
			Object.Instantiate(prefab);
		}
	
	}

	void Shoot(){
		timer = 0f;


		gunLight.enabled = true;
		//gunLine.SetPosition (1, shot.point);
		//

		if(Physics.Raycast(shotCheck,out shot, range, shootableMask)){
			EnemyHealth enemyHealth = shot.collider.GetComponent<EnemyHealth> ();
			if(enemyHealth != null){
				print("bang!");
				enemyHealth.TakeDMG(dmg, shot.point);
			}
		}

	}
}
