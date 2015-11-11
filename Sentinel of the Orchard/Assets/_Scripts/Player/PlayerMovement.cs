using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float walkAccel;
	public GameObject playerCamera;
	Rigidbody rigidbody;


	public float maxWalkSpeed = 20f;

	public Vector2 horizontalMovement;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	/*	Vector3 tempPos;
		horizontalMovement = new Vector2(rigidbody.velocity.x, rigidbody.velocity.z);
		if (horizontalMovement.magnitude > maxWalkSpeed) {
			horizontalMovement = horizontalMovement.normalized;
			horizontalMovement *= maxWalkSpeed;
		}
		rigidbody.velocity.x = horizontalMovement.x;
		rigidbody.velocity.z = horizontalMovement.y;
*



		transform.rotation = Quaternion.Euler (0, playerCamera.GetComponent <CameraControll>().currentYRot, 0);
		if (rigidbody.velocity.x < maxWalkSpeed && rigidbody.velocity.z < maxWalkSpeed) {
		rigidbody.AddRelativeForce(Input.GetAxis ("Horizontal") * walkAccel, 0, Input.GetAxis ("Vertical") * walkAccel);*/


	}
}
