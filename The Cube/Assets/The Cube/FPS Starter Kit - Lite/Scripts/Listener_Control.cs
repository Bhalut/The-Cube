using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener_Control : MonoBehaviour {

	void Update () {
		
		if (PlayerPrefs.GetInt ("audio") == 0) {
			transform.GetComponent<AudioListener>().enabled=false;// audio listener off
		}
		else{
			transform.GetComponent<AudioListener>().enabled=true;// audio listener on
		}
	}
}
