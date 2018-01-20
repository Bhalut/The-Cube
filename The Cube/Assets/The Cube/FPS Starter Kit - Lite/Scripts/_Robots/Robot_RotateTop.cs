using UnityEngine;
using System.Collections;

public class Robot_RotateTop : MonoBehaviour {
	
	public float RotationSpeedTop;// rotation speed
	private Transform target;// robot target
	public Transform top;// link to robot top


	void Start () {
		
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;// find palayer
	
	}

	void Update () {
		
		top.transform.rotation = Quaternion.Slerp(top.transform.rotation, Quaternion.LookRotation(target.position - top.transform.position), RotationSpeedTop  * Time.deltaTime);// look at player
	
	}
}
