using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour 
{

	public static Planet planet;
	public float gravitationalForce;

	public List<Rigidbody> objetos;

	void Awake () 
	{
		planet = this;
	}

	void FixedUpdate()
	{
		foreach (Rigidbody objeto in objetos ) 
		{
			Vector3 directionGravity = (objeto.transform.position - transform.position).normalized;
			Vector3 directionObject = objeto.transform.up;
			objeto.AddForce (directionGravity * gravitationalForce * Time.fixedDeltaTime);
			Quaternion nRotation = Quaternion.FromToRotation (directionObject, directionGravity) * objeto.transform.rotation;
			objeto.transform.rotation = Quaternion.Slerp (objeto.transform.rotation, nRotation, 50 * Time.fixedDeltaTime);
		}
	}
}
