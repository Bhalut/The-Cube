using UnityEngine;
using System.Collections;

public class IntanceObject : MonoBehaviour {

    public Transform prefab;
	
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Prueba Input");
			instanciandoAndo();
		}
	}

    void instanciandoAndo()
    {
        int xRandom = Random.Range(1, 15);
        int yRandom = Random.Range(1, 20);
        int zRandom = Random.Range(-1, 5);
        Instantiate(prefab, new Vector3(xRandom, yRandom, zRandom),Quaternion.identity);
    }
}
