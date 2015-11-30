using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHP = 100;
	public int currentHP;
	public float sink = 2.5f;
	public int value = 100;
	public Navigation navigation;
	private int points = 100;
	//public AudioClip sound; For futre sound clips

	//Animator anim;
	//AudioSource enemyAudio
	Collider collider;
	bool isDead;
	bool isSink;
	private GameObject player;
	private MoneySystem mSystem;
	PlayerInventory p;
    // Use this for initialization
    void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		mSystem = player.GetComponent<MoneySystem> ();
		collider = GetComponent<Collider> ();
		 p = player.GetComponent<PlayerInventory> ();

		currentHP = startingHP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDMG(int ammount, Vector3 hitPoint){
		if (isDead) {
			return;
		}
		print("HIT");
		currentHP -= ammount;

		//IF we get to making particels it will go here for the hit point of the model.

		if (currentHP <= 0)
		{
		    //towerRef.ClearTargets(gameObject);
			Death();
		}
	}

	void Death(){
		navigation = gameObject.GetComponent<Navigation> ();
		if (navigation != null) {
			navigation.isRIP = false;
			navigation.enabled = false;
		}
		isDead = true;
		Sink ();
		collider.isTrigger = true;



	}

	public void Sink(){
		GetComponent <NavMeshAgent> ().enabled = false;

		GetComponent <Rigidbody> ().isKinematic = true;

		isSink = true;

        //increase player's money.
        mSystem.GainMoney(100);
		p.points = p.points + 100;
		Destroy (gameObject, 2f);
	}

}
