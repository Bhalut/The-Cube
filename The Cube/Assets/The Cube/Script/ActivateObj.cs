using UnityEngine;
using System.Collections;

public class ActivateObj : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
				{
           SeFue();
        }
    }

    void SeFue()
		{
        gameObject.SetActive(false);
        Debug.Log("Objeto desactivado");
        Aparecete();
    }


    void Aparecete()
		{
        Invoke("ActObject", 5);
    }

    void ActObject()
		{
        gameObject.SetActive(true);
        Debug.Log("Objeto activado");
    }
}
