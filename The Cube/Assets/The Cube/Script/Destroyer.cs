using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    public void DeleteOff()
    {
		Destroy(gameObject, 3);
    }


	void OnCollisionStay(Collision collision)
	{
        Destroy(gameObject, 3);
		Debug.Log("Destroy proyectil ");
	}
}
