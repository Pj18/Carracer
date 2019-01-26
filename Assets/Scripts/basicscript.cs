using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basicscript : MonoBehaviour {

	private float timer;
	private bool timeStarted=false;
	private string min;
	private string sec;

	// Use this for initialization
	void Start () {
		StartCoroutine (Wt ());
		//timeStarted = true;
		
	}
	IEnumerator Wt()
	{
		//while(true)
		yield return new WaitForSeconds (5);
		print (timeStarted);
		timeStarted = true;
	}
	// Update is called once per frame
	void Update () {
		if (timeStarted == true) {
			timer += Time.deltaTime;
			  min=Mathf.Floor(timer/60).ToString("00");
			 sec = Mathf.Floor (timer % 60).ToString ("00");
			//string st = gameObject.GetComponent<Text> ().text;
			gameObject.GetComponent<Text>().text = min + ":" + sec;
		}
		
	}

}
