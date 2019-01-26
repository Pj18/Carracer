using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour {

	public Transform car;
	public float distance;
	public float height;
	public float rotationDamping;
	public float heightDamping;
	public float zoomRatio;
	public float defaultFOV;
	private float rotation_vector;
	void Start(){
		Destroy (GameObject.Find("Greeting"), 5);

	}

	void FixedUpdate(){
		//Vector3 local_velocity = car.InverseTransformDirection (car.GetComponent<Rigidbody> ().velocity);

		rotation_vector = car.eulerAngles.y;
		float acceleration = car.GetComponent<Rigidbody> ().velocity.magnitude;
		Camera.main.fieldOfView = defaultFOV  * zoomRatio * Time.deltaTime;
	}

	void LateUpdate()
	{
		float wantedAngle = rotation_vector;
		float wantedHeight = car.position.y + height;
		float myAngle = transform.eulerAngles.y;
		//print (myAngle);
		float myHeight = transform.position.y;

		myAngle = Mathf.Lerp (myAngle, wantedAngle, rotationDamping * Time.deltaTime);
		myHeight = Mathf.Lerp (myHeight, wantedHeight, heightDamping * Time.deltaTime);
		//print (myAngle);

		Quaternion currentRotation = Quaternion.Euler (0, myAngle, 0);
		//print (currentRotation);

		transform.position = car.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		Vector3 temp = transform.position;
		temp.y = myHeight;
		transform.position = temp;
		transform.LookAt (car);
	}
}
