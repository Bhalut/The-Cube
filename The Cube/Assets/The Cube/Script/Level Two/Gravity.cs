using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Gravity : MonoBehaviour 
{

	void Start () 
	{
		Planet.planet.objetos.Add (GetComponent<Rigidbody> ());
	}
}
