using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField]
	private Enemy _enemy;
	private float spawnTime = 3f;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		Instantiate (_enemy, this.transform.position, this.transform.rotation);
	}
}
