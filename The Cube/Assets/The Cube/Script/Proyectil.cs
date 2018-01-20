using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {

	//public Transform prefab;
    public Rigidbody proyectile;
    public int velocityProyectil;

	void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.timeScale == 1.0f)
		{
			Debug.Log("Prueba Input");
            //instanciandoAndo();
            Rigidbody clone;
            clone = Instantiate(proyectile, transform.position, transform.rotation) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.forward * velocityProyectil);
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>(), true);
            clone.GetComponent<Destroyer>().DeleteOff();
		}
	}

	/*void instanciandoAndo()
	{
		int xRandom = Random.Range(1, 1);
		int yRandom = Random.Range(1, 1);
		int zRandom = Random.Range(1, 1);
		Instantiate(prefab, new Vector3(xRandom, yRandom, zRandom), Quaternion.identity);
	}*/
}
