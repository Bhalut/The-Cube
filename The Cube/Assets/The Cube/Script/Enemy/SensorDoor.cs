using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorDoor : MonoBehaviour {
		
	public GameObject sensorDoor;

	private Animator anim;

	void Awake()
	{
		anim = sensorDoor.GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			anim.SetBool("IsOpen", true);
		}
	}
}
