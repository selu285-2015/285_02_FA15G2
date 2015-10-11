using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NexusHP : MonoBehaviour {

	public int startingHP;
	public int currentHP;
	public Slider hitPoints;

	bool isDead;
	bool damage;


	// Use this for initialization
	void Start() {
		currentHP = startingHP;
	}

	
	
	public void TakeDamage (int amount)
	{
		damage = true;

		currentHP -= amount;
		

		hitPoints.value = currentHP;
		if (currentHP <= 0 && !isDead) {
			// ... it should die.
			Death ();
		}

	}
		// Update is called once per frame
		void Update () {
			if (damage)
			{
				//for later effects
		}
		damage = false;
	}

	void Death()
	{
		isDead = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		int level = 2; 
		Application.LoadLevel (level);
	}
}
