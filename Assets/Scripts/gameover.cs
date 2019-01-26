using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}

	public void dis(float tim)
	{
		gameObject.SetActive (true);
		print ("hola");
		string crr_min = Mathf.Floor ((tim) / 60).ToString ("00");
		string crr_sec = Mathf.Floor ((tim) % 60).ToString ("00");
		GameObject.Find ("Canvas/overscrn/crrscr_value").GetComponent<Text>().text =crr_min + ":" + crr_sec;

		if (Mathf.Floor ((tim) / 60) < PlayerPrefs.GetInt ("hgh_min", 999999999)) {
			PlayerPrefs.SetInt ("hgh_min", (int)Mathf.Floor ((tim) / 60));
			PlayerPrefs.SetInt ("hgh_sec", (int)Mathf.Floor ((tim) % 60));
			GameObject.Find ("Canvas/overscrn/hghscr_value").GetComponent<Text> ().text = crr_min + ":" + crr_sec;
		} else if (Mathf.Floor ((tim) / 60) == PlayerPrefs.GetInt ("hgh_min", 999999999)) {
			if (Mathf.Floor ((tim) % 60) < PlayerPrefs.GetInt ("hgh_sec", 0)) {
				PlayerPrefs.SetInt ("hgh_min", (int)Mathf.Floor ((tim) / 60));
				PlayerPrefs.SetInt ("hgh_sec", (int)Mathf.Floor ((tim) % 60));
				GameObject.Find ("Canvas/overscrn/hghscr_value").GetComponent<Text> ().text = crr_min + ":" + crr_sec;
			}
			else {
				GameObject.Find ("Canvas/overscrn/hghscr_value").GetComponent<Text> ().text = PlayerPrefs.GetInt ("hgh_min", 0).ToString("00") + ":" + PlayerPrefs.GetInt ("hgh_sec", 0).ToString("00");
			}
		} else {
			GameObject.Find ("Canvas/overscrn/hghscr_value").GetComponent<Text> ().text = PlayerPrefs.GetInt ("hgh_min", 0).ToString("00") + ":" + PlayerPrefs.GetInt ("hgh_sec", 0).ToString("00");
		}
	}


	

}
