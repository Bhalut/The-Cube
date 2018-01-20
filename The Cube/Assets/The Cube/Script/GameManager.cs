using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	bool gameHasEnded = false;

	public void EndGame()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
		}
	}
}
