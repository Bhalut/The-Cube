using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlatform : MonoBehaviour {
	
	private Animator anim;
	[SerializeField]
	private GameObject platform;
	[SerializeField]
	private GameObject player;

	void Start () {
		anim = platform.GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")) {
			player.transform.SetParent (this.transform);
			anim.SetBool ("IsPlatform", true);
		}
	}

	void OnTriggerExit(){
		player.transform.SetParent (null);
	}
}
