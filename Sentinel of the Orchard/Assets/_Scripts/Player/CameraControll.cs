using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public float lookSensitivity =5f;
	public float smoothSpeed = 0.1f;

	float xRotation;
	float yRotation;
	//This is used to smooth camera movement can change if unwanted, but this is SOO smooth
	float currentXRot;
	public float currentYRot;
	float xRotationV;
	float yRotationV;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		xRotation -= Input.GetAxis ("Mouse Y") * lookSensitivity;
		yRotation += Input.GetAxis ("Mouse X") * lookSensitivity;
		//Keeps player from looking down/up infintely Mathf.Clamp allows Xrotation to never be above -90, or 90.
		xRotation = Mathf.Clamp (xRotation, -90, 90);

		//Experimental stuffs
		//SmoothDamp allows the camera to smoothly rotate instead of sharply, Mathf is basic mathematical functions.
		currentXRot = Mathf.SmoothDamp (currentXRot, xRotation, ref xRotationV, smoothSpeed);
		currentYRot = Mathf.SmoothDamp (currentYRot, yRotation, ref yRotationV, smoothSpeed);
		//this returns a rotation that will update based off the variables, it transforms whatever game object the script is attatched to.
		transform.rotation = Quaternion.Euler (currentXRot, currentYRot, 0);
	}
}
