using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCube : MonoBehaviour {

	void OnDrawGizmosSelected(){
		Gizmos.color = new Color (1, 0, 0, 0.75f);
		Gizmos.DrawCube (transform.position, new Vector3 (10, 10, 10));
	}

}
