using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorEnemy : MonoBehaviour
{
	[SerializeField]
	private GameObject[] _enemy;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < _enemy.Length - 1; i++)
			{
				if (_enemy[i] != null)
				{
					_enemy [i].SetActive (true);
				}
			}
		}
	}
}
