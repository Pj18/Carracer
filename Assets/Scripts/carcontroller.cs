using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour {

	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;
	public float breakTor;
	public float sp;
	private int count=0;
	private float timer;
	private bool timeStarted=false;
	public GameObject gg;
	//public gameover gg;

	void Start()
	{
		StartCoroutine (Wt ());
	}
	void Update()
	{
		if (timeStarted == true) {
			timer += Time.deltaTime;
		}
	}
	void OnTriggerEnter(Collider other){
		print (other.gameObject.name);
		if (other.gameObject.tag == "CheckPoints") {
			count++;

			Destroy (other.gameObject);
			if (count == 8) {
				//gameover.dis ();
				gameObject.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;

				//GameObject gg=GameObject.Find ("Canvas/overscrn")/*.GetComponent<GameOver> ().dis ()*/;
				print (gg);
				//print (gg.GetComponents(typeof(gameover)));
				gameover go = (gameover)gg.GetComponent<gameover> ();
				go.dis (timer);
			}
		}
	}
	IEnumerator Wt()
	{
		//while(true)
		yield return new WaitForSeconds (5);
		print (timeStarted);
		timeStarted = true;
	}
	public void FixedUpdate()
	{
		float motor = 0;
		float steering = 0;
		 motor = maxMotorTorque * Input.GetAxis ("Vertical");
		 steering = maxSteeringAngle * Input.GetAxis ("Horizontal");


		foreach (AxleInfo axleInfo in axleInfos) {
			
			if (axleInfo.steering) {
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}
			if (axleInfo.motor) {
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}
		}
		  sp=gameObject.GetComponent<Rigidbody> ().velocity.magnitude;
		if (Input.GetButton ("Vertical") == false&&Input.GetButton("Horizontal")==false) {
			//print ("hola");
			foreach (AxleInfo axleinfo in axleInfos) {
				axleinfo.leftWheel.brakeTorque = breakTor;
				axleinfo.rightWheel.brakeTorque = breakTor;
			}
		} else {
			foreach (AxleInfo axleinfo in axleInfos) {
				axleinfo.leftWheel.brakeTorque = 0;
				axleinfo.rightWheel.brakeTorque = 0;
			}
		}



	}

}

[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor; // is this wheel attached to motor?
	public bool steering; // does this wheel apply steer angle?
}
